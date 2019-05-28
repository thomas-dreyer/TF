using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFAPI.ViewModels
{
    public class CurrencyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Surcharge { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<ExchangeRateViewModel> ExchangeRates { get; set; }
    }
}