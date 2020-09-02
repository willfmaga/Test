using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public void Incluir(Pessoa pessoa)
        {
            dbSet.Add(pessoa);
            contexto.SaveChanges();
        }
    }
}
