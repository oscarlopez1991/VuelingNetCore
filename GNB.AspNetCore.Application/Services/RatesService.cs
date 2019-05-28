using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using GNB.AspNetCore.Application.DTOs;
using GNB.AspNetCore.Application.Models;
using GNB.AspNetCore.Application.Repositories.Contracts;

namespace GNB.AspNetCore.Application.Services
{
    public class RatesService : IRatesService
    {
        private readonly string path = @"http://quiet-stone-2094.herokuapp.com/rates.json";
        private readonly IMapper mapper;
        private readonly IRateRepository repository;

        public RatesService(IMapper mapper, IRateRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<IEnumerable<RatesDTO>> GetAllRatesAsync()
        {
            IEnumerable<Rates> rates = null;

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    rates = await response.Content.ReadAsAsync<IEnumerable<Rates>>();
                    await repository.DeleteAllRatesAsync();
                    await repository.AddRatesAsync(rates);
                }
                else
                {
                    rates = await repository.GetRatesAsync();
                }
                return mapper.Map<IEnumerable<RatesDTO>>(rates);
            }
        }
    }
}
