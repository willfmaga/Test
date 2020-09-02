using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Domain.Entities;

namespace Teste.Data
{
    public class RepomVisaCampanhaContexto : DbContext
    {
        public RepomVisaCampanhaContexto(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>().HasKey(t => t.Id);
            modelBuilder.Entity<Pessoa>().HasMany(p => p.veiculos);

            modelBuilder.Entity<Veiculo>().HasKey(v => v.Id);
            modelBuilder.Entity<Veiculo>().HasOne(v => v.pessoa);


        }
    }
}
