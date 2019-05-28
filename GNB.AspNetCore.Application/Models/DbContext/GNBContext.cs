using System;
using Microsoft.EntityFrameworkCore;

namespace GNB.AspNetCore.Application.Models.SqLite
{
    public class GNBContext : DbContext
    {
        public DbSet<Rates> Rates { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        public GNBContext()
        {
        }

        public GNBContext(DbContextOptions<GNBContext> options)
            : base(options)
        {
        }
    }
}
