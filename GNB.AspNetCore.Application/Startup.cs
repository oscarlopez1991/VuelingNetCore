using AutoMapper;
using GNB.AspNetCore.Application.Models.SqLite;
using GNB.AspNetCore.Application.Repositories.Contracts;
using GNB.AspNetCore.Application.Repository;
using GNB.AspNetCore.Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GNB.AspNetCore.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton(Configuration);
            services.AddScoped<IRatesService, RatesService>();
            services.AddScoped<ITransactionsService, TransactionsService>();
            services.AddScoped<ITransactionsBySkuService, TransactionsBySkuService>();
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddDbContext<GNBContext>(options => options.UseSqlite(Configuration.GetConnectionString("GNBConnection")));
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}