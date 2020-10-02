using System;
using System.Collections.Generic;
using System.Text;
using Teste.Infra.CrossCutting.JobConfiguration.Entities;

namespace Teste.Application.Interfaces
{
    public interface IJobConfigurationApp
    {
        StandardJobResponse DefaultJobExecution(StandardJobRequest request);
    }
}
