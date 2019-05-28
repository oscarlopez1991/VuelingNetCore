using System.Collections.Generic;
using System.Threading.Tasks;
using GNB.AspNetCore.Application.DTOs;

namespace GNB.AspNetCore.Application.Services
{
    public interface IRatesService
    {
        Task<IEnumerable<RatesDTO>> GetAllRatesAsync();
    }
}
