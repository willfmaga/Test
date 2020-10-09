using System;
using Teste.Domain.Entities;
using Teste.Domain.Interface.Repositories;
using Teste.Domain.Interface.Services;

namespace Teste.Domain
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public Int64 Incluir(Veiculo veiculo)
        {
            return _veiculoRepository.Add(veiculo);
        }
    }
}
