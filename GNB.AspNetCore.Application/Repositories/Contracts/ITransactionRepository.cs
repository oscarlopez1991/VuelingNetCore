using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GNB.AspNetCore.Application.Models;

namespace GNB.AspNetCore.Application.Repositories.Contracts
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transactions>> GetTransactionsAsync();

        Task DeleteAllTransactionsAsync();

        Task AddTransactionsAsync(IEnumerable<Transactions> transactions);
    }
}
