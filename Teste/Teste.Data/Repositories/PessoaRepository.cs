using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Teste.Domain.Entities;
using Teste.Domain.Interface.Repositories;

namespace Teste.Data.Repositories
{
    public class PessoaRepository :BaseRepository<Pessoa>, IPessoaRepository
    {

        public PessoaRepository(RepomVisaCampanhaContexto contexto): base(contexto)
        {
        }

        public Pessoa BuscarPorNome(string nome)
        {
            return dbSet.Where(x => x.Nome == nome)
                .Include(x => x.veiculos)
                .FirstOrDefault();
        }

        public void Incluir(Pessoa pessoa)
        {
            dbSet.Add(pessoa);
            contexto.SaveChanges();
        }
    }
}
