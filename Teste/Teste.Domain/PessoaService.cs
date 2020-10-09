using System;
using System.Collections.Generic;
using System.Text;
using Teste.Domain.Entities;
using Teste.Domain.Interface.Repositories;
using Teste.Domain.Interface.Services;

namespace Teste.Domain
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository )
        {
            this.pessoaRepository = pessoaRepository;
        }

        public Pessoa BuscarPorNome(string nome)
        {
            return pessoaRepository.BuscarPorNome(nome);
        }

        public void Incluir(Pessoa pessoa)
        {
            pessoaRepository.Incluir(pessoa);
        }

    }
}
