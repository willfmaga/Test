using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Teste.Application.Interfaces;
using Teste.Application.Services;
using Teste.Data;
using Teste.Data.Repositories;
using Teste.Domain;
using Teste.Domain.Interface.Repositories;
using Teste.Domain.Interface.Services;

namespace Teste.WebAPI
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
            services.AddControllersWithViews();

            var connectionString = Configuration.GetConnectionString("RepomVisaVaiDeVisa");

            services.AddDbContext<RepomVisaCampanhaContexto>
            (
               options => options.UseSqlServer(connectionString)
            );

            services.AddTransient<IPessoaApp, PessoaApp>();
            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<IPessoaRepository,PessoaRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Pessoa}/{action=Create}/{id?}");
            });

            serviceProvider.GetService<RepomVisaCampanhaContexto>().Database.Migrate();
        }
    }
}
