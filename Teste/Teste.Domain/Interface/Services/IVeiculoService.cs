using System;
using System.Collections.Generic;
using System.Text;
using Teste.Domain.Entities;

namespace Teste.Domain.Interface.Services
{
    public interface IVeiculoService
    {
        public Int64 Incluir(Veiculo veiculo);
    }
}
