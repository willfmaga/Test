using System;
using System.Collections.Generic;
using System.Text;
using Teste.Domain.Entities;

namespace Teste.Domain.Interface.Repositories
{
    public interface IVeiculoRepository
    {
        public Int64 Add(Veiculo veiculo);
    }
}
