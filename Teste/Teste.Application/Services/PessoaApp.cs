using AutoMapper;
using System;
using Teste.Application.Interfaces;
using Teste.Application.Interfaces.Model;
using Teste.Application.Registration;
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
        private readonly IMapper mapper = AutoMapperConfig.Mapper;

        public PessoaApp(IPessoaService pessoaService)
        {
            this.pessoaService = pessoaService;
        }

        public void Incluir(PessoaDTO pessoaDTO)
        {


            var resultValidation = new PessoaDTOValidator().Validate(pessoaDTO);
            if (!resultValidation.IsValid) throw new RepomVaiDeVisaException(resultValidation);

            var pessoa = mapper.Map<Pessoa>(pessoaDTO);

            pessoaService.Incluir(pessoa);
        }
    }
}
