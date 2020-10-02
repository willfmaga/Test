using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Infra.CrossCutting.JobConfiguration.Entities;

namespace Teste.Infra.CrossCutting.JobConfiguration
{
    public class JobConfigurationContexto: DbContext
    {

        public JobConfigurationContexto(DbContextOptions<JobConfigurationContexto> dbcontextOptions): base (dbcontextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ConfiguracaoJob>().HasKey(t => t.Id);
            modelBuilder.Entity<ConfiguracaoJob>().HasMany(t => t.Agendamentos).WithOne(t => t.ConfiguracaoJob).IsRequired();

            modelBuilder.Entity<ConfiguracaoJobAgendamento>().HasKey(g => g.Id);
            modelBuilder.Entity<ConfiguracaoJobAgendamento>().HasOne(c => c.ConfiguracaoJob);


        }
    }
}
