using System;
using System.Collections.Generic;
using System.Text;
using Teste.Domain.Entities;
using Teste.Domain.Interface.Repositories;

namespace Teste.Data.Repositories
{
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(RepomVisaCampanhaContexto contexto):base(contexto)
        {

        }


    }
}
