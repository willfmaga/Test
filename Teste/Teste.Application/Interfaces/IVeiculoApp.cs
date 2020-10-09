using System;
using System.Collections.Generic;
using System.Text;
using Teste.Application.Interfaces.Model;
using Teste.Application.Model;

namespace Teste.Application.Interfaces
{
    public interface IVeiculoApp
    {
        VeiculoDTO Incluir(VeiculoDTO veiculoDTO);
    }
}
