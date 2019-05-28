using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using GNB.AspNetCore.Application.DTOs;
using GNB.AspNetCore.Application.Models;
using GNB.AspNetCore.Application.Repositories.Contracts;

namespace GNB.AspNetCore.Application.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly string path = @"http://quiet-stone-2094.herokuapp.com/transactions.json"; //TODO mejor manera de definir la ruta?
        private readonly IMapper mapper;
        private readonly ITransactionRepository repository;

        public TransactionsService(IMapper mapper, ITransactionRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<IEnumerable<TransactionsDTO>> GetTransactionsAsync()
        {
            IEnumerable<Transactions> transactions = null;

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    transactions = await response.Content.ReadAsAsync<IEnumerable<Transactions>>();
                    await repository.DeleteAllTransactionsAsync();
                    await repository.AddTransactionsAsync(transactions);
                }
                else
                {
                    transactions = await repository.GetTransactionsAsync();
                }
            }
            return mapper.Map<IEnumerable<TransactionsDTO>>(transactions);
        }

        public async Task<IEnumerable<TransactionsDTO>> GetTransactionsBySkuAsync(string sku) //TODO ver si definirlo con sku optional y no implementar éste método
        {
            var transactions = await GetTransactionsAsync();

            return transactions.Where(x => x.Sku == sku);
        }
    }
}
