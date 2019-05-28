using SQLite;

namespace GNB.AspNetCore.Application.Models
{
    public class Transactions
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
        [NotNull]
        public string Sku { get; set; }
        [NotNull]
        public decimal Amount { get; set; }
        [NotNull]
        public string Currency { get; set; }
    }
}
