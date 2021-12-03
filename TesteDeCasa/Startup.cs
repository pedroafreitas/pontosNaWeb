using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TesteDeCada.Services.Implementations;
using TesteDeCasa.DAL;
using TesteDeCasa.Services.Implementations;
using TesteDeCasa.Services.Interfaces;
using TesteDeCasa.Utils;

namespace TesteDeCasa
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

            services.AddDbContext<BankingDbContext>(ctx => ctx.UseSqlServer(Configuration.GetConnectionString("BankingDbConnection")));

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransactionService, TransactionService>();
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                { 
                    Title = "TesteDeCasa", 
                    Version = "v2",
                    Description = "Resolvendo o teste back-end c#",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Pedro Arthur",
                        Email = "pedro.afd@discent.ufma.br",
                        Url = new Uri("https://github.com/pedroafreitas")
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(x =>
            {
                var prefix = string.IsNullOrEmpty(x.RoutePrefix) ? "." : "..";
                x.SwaggerEndpoint($"{prefix}/swagger/v2/swagger.json", "Api de Banco do Teste De Casa");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
