using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFAPI.ViewModels
{
    public class ExchangeRateViewModel
    {
        public string LocalCurrency { get; set; }
        public string ForeignCurrency { get; set; }
        public double Rate { get; set; }
    }
}