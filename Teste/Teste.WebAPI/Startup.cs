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
using Quartz;
using Quartz.Impl;
using Teste.Application.Interfaces;
using Teste.Application.Services;
using Teste.Data;
using Teste.Data.Repositories;
using Teste.Domain;
using Teste.Domain.Interface.Repositories;
using Teste.Domain.Interface.Services;
using Teste.Infra.CrossCutting.JobConfiguration;
using Teste.Infra.CrossCutting.JobConfiguration.Repositories;
using Teste.Infra.CrossCutting.JobConfiguration.Repositories.Interface;
using Teste.Infra.CrossCutting.JobConfiguration.Services.Interfaces;
using Teste.Infra.CrossCutting.Services;
using Teste.WebAPI.Bus.Rabbit;
using Teste.WebAPI.SchuduleJobs;

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

            services.AddTransient<IJobConfigurationService, JobConfigurationService>();

            services.AddDbContext<RepomVisaCampanhaContexto>
            (
               options => options.UseSqlServer(connectionString)
            );

            services.AddDbContext<JobConfigurationContexto>
            (
               options => options.UseSqlServer(connectionString)
            );
            services.AddTransient<ScheduleJobsConfiguration>();

            services.AddTransient<IPessoaApp, PessoaApp>();
            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<IPessoaRepository, PessoaRepository>();
            services.AddTransient<IJobConfigurationApp, JobConfigurationApp>();
            services.AddTransient<IJobConfigurationRepository, JobConfigurationRepository>();
            services.AddTransient<IVeiculoApp, VeiculoApp>();
            services.AddTransient<IVeiculoService, VeiculoService>();
            services.AddTransient<IVeiculoRepository, VeiculoRepository>();

            //iniciando a leitura de fila 
            services.AddHostedService<RabbitConsumer>();
            
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
                    pattern: "{controller=Veiculo}/{action=Create}/{id?}");
            });

            serviceProvider.GetService<JobConfigurationContexto>().Database.Migrate();
            serviceProvider.GetService<RepomVisaCampanhaContexto>().Database.Migrate();
            //Iniciando os serviços do Quarts
            this.SchedulerServiceConfiguration(serviceProvider);

        }

        public void SchedulerServiceConfiguration(IServiceProvider services)
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = factory.GetScheduler().Result;
            scheduler.Start().Wait();

            services.GetService<ScheduleJobsConfiguration>().ScheduleJobs(scheduler);
        }
    }
}
