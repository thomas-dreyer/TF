using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TFAPI.Models;
using TFAPI.Providers;
using TFAPI.ViewModels;

namespace TFAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, PUT, POST")]
    public class OrderController : ApiController
    {
        MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Currency, CurrencyViewModel>();
            cfg.CreateMap<Order, OrderViewModel>();
        });

        private void CalculateConversion(Order order)
        {
            ExchangeRate rate = APIDbContext.Instance.ExchangeRates.Where(x => x.ForeignCurrency == order.ForeignCurrency.Id).FirstOrDefault();
            order.Rate = rate.Rate;
            order.Surcharge = order.ForeignCurrency.Surcharge;
            order.DateCreated = DateTime.Now;
            order.LocalCurrencyAmount = order.ForeignCurrencyAmount / order.Rate;
            order.SurchargeAmount = order.LocalCurrencyAmount * order.ForeignCurrency.Surcharge / 100;
        }


        [HttpGet]
        public IEnumerable<OrderViewModel> Get()
        {
            List<OrderViewModel> models = new List<OrderViewModel>();
            try
            {
                var mapper = config.CreateMapper();
                var currencies = APIDbContext.Instance.Currencies;
                var orders = APIDbContext.Instance.Orders;
                foreach (var order in orders)
                {
                    var model = mapper.Map<Order, OrderViewModel>(order);
                    model.ForeignCurrency = order.ForeignCurrency.Id;
                    model.LocalCurrency = order.LocalCurrency.Id;
                    models.Add(model);
                }
            }
            catch (Exception)
            { }
            return models;
        }

        [HttpPost]
        public OperationResultViewModel Post(OrderViewModel model)
        {
            OperationResultViewModel result = new OperationResultViewModel();
            if (model.LocalCurrencyAmount <= 0 || model.ForeignCurrencyAmount <= 0)
            {
                result.Result = "Failed";
                result.MetaData = "Cannot buy a negative amount.";
            }
            else
            {
                try
                {
                    var mapper = config.CreateMapper();
                    var currencies = APIDbContext.Instance.Currencies;
                    var orders = APIDbContext.Instance.Orders;
                    var currencyAction = APIDbContext.Instance.CurrencyActions;
                    Order order = mapper.Map<OrderViewModel, Order>(model);
                    order.LocalCurrency = currencies.Where(x => x.Id == model.LocalCurrency).FirstOrDefault();
                    order.ForeignCurrency = currencies.Where(y => y.Id == model.ForeignCurrency).FirstOrDefault();

                    CalculateConversion(order);
                    var actions = currencyAction.Where(x => x.CurrencyId == order.ForeignCurrency.Id);
                    // apply currency actions
                    foreach (var action in actions)
                    {
                        Action myFunction = null;
                        if (action.Key == "Discount")
                        {
                            myFunction = () =>
                            {
                                double discount = 0;
                                if(double.TryParse(action.Value, out discount))
                                {
                                    order.Discount = order.LocalCurrencyAmount * discount / 100;
                                }
                            };

                        }
                        if (myFunction != null)
                        {
                            action.ApplyAction(myFunction);
                        }
                    }
                    orders.Add(order);
                    APIDbContext.Instance.SaveChanges();
                    result.Result = "Success";
                    result.MetaData = "Your order has been placed.";
                }
                catch (Exception ex)
                {
                    result.Result = "Error";
                    result.MetaData = ex.Message;
                }
            }

            return result;
        }
    }
}
