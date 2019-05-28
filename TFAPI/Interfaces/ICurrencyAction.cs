using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFAPI.Interfaces
{
    public interface ICurrencyAction
    {
        [Key]
        int Id { get; set; }

        int CurrencyId { get; set; }

        List<KeyValuePair<string, string>> Settings { get; set; }

        void ApplyAction();
    }
}
