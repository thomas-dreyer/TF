using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TFAPI.Models
{
    public class ExchangeRate
    {
        [Key, Column(Order = 0)]
        public int LocalCurrency { get; set; }
        [Key, Column(Order = 1)]
        public int ForeignCurrency { get; set; }
        public double Rate { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}