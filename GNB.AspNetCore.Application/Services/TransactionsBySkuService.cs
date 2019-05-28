using System;
using System.Collections.Generic;
using GNB.AspNetCore.Application.Models;
using GNB.AspNetCore.Application.Services;

namespace GNB.AspNetCore.Application.Services
{
    public class TransactionsBySkuService : ITransactionsBySkuService
    {
        private readonly ITransactionsService transactionService;
        private readonly IRatesService rateService;

        public TransactionsBySkuService(ITransactionsService transactionService, IRatesService rateService)
        {
            this.transactionService = transactionService;
            this.rateService = rateService;
        }

        public IEnumerable<Transactions> ConvertToEUR(string sku)
        {
            var transactions = transactionService.GetTransactionsBySkuAsync(sku);
            var rates = rateService.GetAllRatesAsync();



            return null; //TODO
        }
    }
}
