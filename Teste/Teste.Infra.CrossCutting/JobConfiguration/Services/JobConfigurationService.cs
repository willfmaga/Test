
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Infra.CrossCutting.JobConfiguration.Entities;
using Teste.Infra.CrossCutting.JobConfiguration.Repositories.Interface;
using Teste.Infra.CrossCutting.JobConfiguration.Services.Interfaces;

namespace Teste.Infra.CrossCutting.Services
{
    public class JobConfigurationService : IJobConfigurationService
    {
        private readonly IJobConfigurationRepository jobConfigurationRepository;

        public JobConfigurationService(IJobConfigurationRepository jobConfigurationRepository)
        {
            this.jobConfigurationRepository = jobConfigurationRepository;
        }

        public List<ConfiguracaoJob> GetAll()
        {
            return jobConfigurationRepository.GetAll();
        }
    }
}
