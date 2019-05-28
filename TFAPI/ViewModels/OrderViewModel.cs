using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFAPI.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int LocalCurrency { get; set; }
        public int ForeignCurrency { get; set; }
        public double LocalCurrencyAmount { get; set; }
        public double ForeignCurrencyAmount { get; set; }
        public double Rate { get; set; }
        public double Surcharge { get; set; }
        public double SurchargeAmount { get; set; }
        public double Discount { get; set; }
        public DateTime DateCreated { get; set; }
    }
}