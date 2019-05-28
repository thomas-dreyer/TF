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
    public class CurrencyController : ApiController
    {
        MapperConfiguration config = new MapperConfiguration(cfg => {
            cfg.CreateMap<Currency, CurrencyViewModel>();
            cfg.CreateMap<ExchangeRate, ExchangeRateViewModel>();
        });

        [HttpGet]
        public IEnumerable<CurrencyViewModel> Get()
        {
            List<CurrencyViewModel> models = new List<CurrencyViewModel>();
            try
            {
                var currencies = APIDbContext.Instance.Currencies;
                var exchangeRate = APIDbContext.Instance.ExchangeRates;

                var mapper = config.CreateMapper();

                foreach (var currency in currencies.Where(x => x.Id > 1))
                {
                    CurrencyViewModel currencyViewModel = mapper.Map<Currency, CurrencyViewModel>(currency);
                    currencyViewModel.ExchangeRates = new List<ExchangeRateViewModel>();
                    var filter = exchangeRate.Where(x => x.ForeignCurrency == currencyViewModel.Id).ToList();

                    foreach (var rate in filter)
                    {
                        currencyViewModel.ExchangeRates.Add(mapper.Map<ExchangeRate, ExchangeRateViewModel>(rate));
                    }
                    models.Add(currencyViewModel);
                }
            }
            catch (Exception)
            { }
            return models;
        }

    }
}
