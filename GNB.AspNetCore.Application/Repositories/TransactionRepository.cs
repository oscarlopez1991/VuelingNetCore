using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GNB.AspNetCore.Application.Models;
using GNB.AspNetCore.Application.Models.SqLite;
using GNB.AspNetCore.Application.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GNB.AspNetCore.Application.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly GNBContext context;

        public TransactionRepository(GNBContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Transactions>> GetTransactionsAsync()
        {
            return await context.Transactions.ToListAsync();
        }

        public async Task DeleteAllTransactionsAsync()
        {
            var transactions = await GetTransactionsAsync();
            context.Transactions.RemoveRange(transactions);
        }

        public async Task AddTransactionsAsync(IEnumerable<Transactions> transactions)
        {
            await context.Transactions.AddRangeAsync(transactions);
            await context.SaveChangesAsync();
        }
    }
}
