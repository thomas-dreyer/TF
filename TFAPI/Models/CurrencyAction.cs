using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFAPI.Interfaces;

namespace TFAPI.Models
{
    public class CurrencyAction
    {
        public int CurrencyId { get; set; }
       
        public int Id { get; set; }

        public string Key { get; set; }
        public string Value { get; set; }

        public void ApplyAction(Action action) 
        {
            action.Invoke();
        }
    }
}