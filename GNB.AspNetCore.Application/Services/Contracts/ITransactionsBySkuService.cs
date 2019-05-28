using System;
using System.Collections.Generic;
using GNB.AspNetCore.Application.Models;

namespace GNB.AspNetCore.Application.Services
{
    public interface ITransactionsBySkuService
    {
        IEnumerable<Transactions> ConvertToEUR(string sku);
    }
}
