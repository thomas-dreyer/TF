using System.Data.Entity;
using TFAPI.Models;

namespace TFAPI.Providers
{
    public sealed class APIDbContext: DbContext
    {
        private static readonly APIDbContext instance = new APIDbContext();

        public static APIDbContext Instance
        {
            get { return instance; }
        }

        public  DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CurrencyAction> CurrencyActions { get; set; }
    }
}