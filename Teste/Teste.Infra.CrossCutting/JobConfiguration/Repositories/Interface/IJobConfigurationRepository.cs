using System;
using System.Collections.Generic;
using System.Text;
using Teste.Infra.CrossCutting.JobConfiguration.Entities;

namespace Teste.Infra.CrossCutting.JobConfiguration.Repositories.Interface
{
    public interface IJobConfigurationRepository
    {
        List<ConfiguracaoJob> GetAll();

    }
}
