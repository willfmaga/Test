using System;
using Teste.Application.Interfaces;
using Teste.Application.Interfaces.Model;
using Teste.Domain;
using Teste.Domain.Entities;
using Teste.Domain.Interface.Services;

namespace Teste.Application.Services
{
    public class PessoaApp : IPessoaApp
    {
        private readonly IPessoaService pessoaService;
        

        public PessoaApp(IPessoaService pessoaService)
        {
            this.pessoaService = pessoaService;
        }

        public void Incluir(PessoaDTO pessoaDTO)
        {
            var pessoa = new Pessoa();
            //mappear 
            //validation 

            pessoa.Id = 1;
            pessoa.Nome = pessoaDTO.Nome;
            pessoa.Sobrenome = pessoaDTO.Sobrenome;

            pessoaService.Incluir(pessoa);
        }
    }
}
