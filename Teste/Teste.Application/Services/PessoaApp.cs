using System;
using Teste.Application.Interfaces;
using Teste.Application.Interfaces.Model;
using Teste.Application.Validation;
using Teste.Domain;
using Teste.Domain.Entities;
using Teste.Domain.Interface.Services;
using Teste.Infra.CrossCutting.CustomError;

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

            var resultValidation = new PessoaDTOValidator().Validate(pessoaDTO);
            if (!resultValidation.IsValid) throw new RepomVaiDeVisaException(resultValidation);

            pessoa.Id = new Random().Next(1,100);
            pessoa.Nome = pessoaDTO.Nome;
            pessoa.Sobrenome = pessoaDTO.Sobrenome;

            pessoaService.Incluir(pessoa);
        }
    }
}
