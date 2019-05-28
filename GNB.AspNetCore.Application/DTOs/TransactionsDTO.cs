namespace GNB.AspNetCore.Application.DTOs
{
    public class TransactionsDTO
    {
        public string Sku { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
