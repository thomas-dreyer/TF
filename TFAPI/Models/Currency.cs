using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFAPI.Interfaces;

namespace TFAPI.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Surcharge { get; set; }
        public virtual ICollection<ICurrencyAction> Actions { get; set; }

        public Currency(int id, string name, ICollection<ICurrencyAction> actions)
        {
            Id = id;
            Name = name;
            Actions = actions;
        }

        public Currency()
        { }

    }
}