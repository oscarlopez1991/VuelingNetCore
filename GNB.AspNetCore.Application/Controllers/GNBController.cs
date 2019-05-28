using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GNB.AspNetCore.Application.DTOs;
using GNB.AspNetCore.Application.Models;
using GNB.AspNetCore.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GNB.AspNetCore.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GNBController : ControllerBase
    {
        private readonly IRatesService rateService;
        private readonly ITransactionsService transactionService;

        public GNBController(IRatesService rateService, ITransactionsService transactionService)
        {
            this.rateService = rateService;
            this.transactionService = transactionService;
        }

        [HttpGet]
        public async Task<IEnumerable<RatesDTO>> GetRatesAsync()
        {
            return await rateService.GetAllRatesAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<TransactionsDTO>> GetTransactionsAsync()
        {
            return await transactionService.GetTransactionsAsync();
        }
    }
}
