using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Application.Interfaces.Model;
using Teste.Application.Model;
using Teste.Domain.Entities;

namespace Teste.Application.Registration
{
    public static class AutoMapperConfig
    {

        private static IMapper mapper;

        public static IMapper Mapper
        {
            get
            {
                if (mapper == null)
                {

                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<PessoaDTO, Pessoa>()
                            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                            .ForMember(dest => dest.Sobrenome, opt => opt.MapFrom(src => src.Sobrenome));

                        cfg.CreateMap<Pessoa, PessoaDTO>();
                        cfg.CreateMap<Veiculo, VeiculoDTO>();
                        cfg.CreateMap<VeiculoDTO, Veiculo>();
                    });

                    mapper = config.CreateMapper();
                }
                return mapper;
            }
        }
    }
}
