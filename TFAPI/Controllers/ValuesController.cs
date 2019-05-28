using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TFAPI.Models;
using TFAPI.Providers;

namespace TFAPI.Controllers
{
    [EnableCors(origins: "localhost", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        APIDbContext db = new APIDbContext();

        // GET api/values
        public IEnumerable<Currency> Get()
        {
            //CurrencyAction action = new CurrencyAction();
            //Action myFunction = () => Console.WriteLine("I am working yo!");

            ////action.ApplyAction(myFunction);
            //db.Currencies.Add(new Models.Currency()
            //{
            //    Id = 1,
            //    Name = "ZAR"
            //});
            //db.Currencies.Add(new Models.Currency()
            //{
            //    Id = 2,
            //    Name = "USD"
            //});
            
            //db.ExchangeRates.Add(new ExchangeRate()
            //{
            //    LocalCurrency = 1,
            //    ForeignCurrency = 2,
            //    Rate = 0.9,
            //    UpdateDateTime = DateTime.Now
            //});
            //db.SaveChanges();
            return db.Currencies;
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
