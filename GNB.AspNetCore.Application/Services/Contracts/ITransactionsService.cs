using System.Collections.Generic;
using System.Threading.Tasks;
using GNB.AspNetCore.Application.DTOs;
using GNB.AspNetCore.Application.Models;

namespace GNB.AspNetCore.Application.Services
{
    public interface ITransactionsService
    {
        Task<IEnumerable<TransactionsDTO>> GetTransactionsAsync();

        Task<IEnumerable<TransactionsDTO>> GetTransactionsBySkuAsync(string sku);
    }
}
