using System;
using System.Collections.Generic;
using System.Text;
using Teste.Domain.Entities;

namespace Teste.Domain.Interface.Repositories
{
    public interface IPessoaRepository
    {
        void Incluir(Pessoa pessoa);
        Pessoa BuscarPorNome(string nome);
    }
}
