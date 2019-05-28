using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GNB.AspNetCore.Application.Models;

namespace GNB.AspNetCore.Application.Repositories.Contracts
{
    public interface IRateRepository
    {
        Task<IEnumerable<Rates>> GetRatesAsync();

        Task DeleteAllRatesAsync();

        Task AddRatesAsync(IEnumerable<Rates> rates);
    }
}
