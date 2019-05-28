using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GNB.AspNetCore.Application.Models;
using GNB.AspNetCore.Application.Models.SqLite;
using GNB.AspNetCore.Application.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GNB.AspNetCore.Application.Repository
{
    public class RateRepository : IRateRepository
    {
        private readonly GNBContext context;

        public RateRepository(GNBContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Rates>> GetRatesAsync()
        {
            return await context.Rates.ToListAsync();
        }

        public async Task DeleteAllRatesAsync()
        {
            var rates = await GetRatesAsync();
            context.Rates.RemoveRange(rates);
        }

        public async Task AddRatesAsync(IEnumerable<Rates> rates)
        {
            await context.Rates.AddRangeAsync(rates);
            await context.SaveChangesAsync();
        }
    }
}
