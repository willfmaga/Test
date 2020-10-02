using System;
using System.Collections.Generic;
using System.Text;
using Teste.Infra.CrossCutting.JobConfiguration.Entities;

namespace Teste.Infra.CrossCutting.JobConfiguration.Services.Interfaces
{
    public interface IJobConfigurationService
    {
        List<ConfiguracaoJob> GetAll();
    }
}
