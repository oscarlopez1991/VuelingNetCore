using SQLite;

namespace GNB.AspNetCore.Application.Models
{
    public class Rates
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string From { get; set; }
        [NotNull]
        public string To { get; set; }
        [NotNull]
        public decimal Rate { get; set; }
    }
}
