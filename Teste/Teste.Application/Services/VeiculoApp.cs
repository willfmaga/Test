using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Application.Interfaces;
using Teste.Application.Interfaces.Model;
using Teste.Application.Model;
using Teste.Application.Registration;
using Teste.Application.Validation;
using Teste.Domain.Entities;
using Teste.Domain.Interface.Services;
using Teste.Infra.CrossCutting.CustomError;

namespace Teste.Application.Services
{
    public class VeiculoApp : IVeiculoApp
    {
        private readonly IMapper _mapper = AutoMapperConfig.Mapper;
        private readonly IVeiculoService _veiculoService;
        private readonly IPessoaService _pessoaService;

        public VeiculoApp(IVeiculoService veiculoService, IPessoaService pessoaService)
        {
            _veiculoService = veiculoService;
            _pessoaService = pessoaService;
        }

        public VeiculoDTO Incluir(VeiculoDTO veiculoDTO)
        {
            var resultvalidation = new VeiculoDTOValidator().Validate(veiculoDTO);
            if (!resultvalidation.IsValid) throw new RepomVaiDeVisaException(resultvalidation);

            var veiculo = _mapper.Map<Veiculo>(veiculoDTO);

            var pessoaDTO = _pessoaService.BuscarPorNome(veiculoDTO.pessoaNome);

            veiculo.pessoa = _mapper.Map<Pessoa>(pessoaDTO);

            _veiculoService.Incluir(veiculo);

            return _mapper.Map<VeiculoDTO>(veiculo);
        }
    }
}
