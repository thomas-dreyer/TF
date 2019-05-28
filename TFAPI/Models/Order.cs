using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Currency LocalCurrency { get; set; }
        public Currency ForeignCurrency { get; set; }
        public double LocalCurrencyAmount { get; set; }
        public double ForeignCurrencyAmount { get; set; }
        public double Rate { get; set; }
        public double Surcharge { get; set; }
        public double SurchargeAmount { get; set; }
        public double Discount { get; set; }
        public DateTime DateCreated { get; set; }
    }
}