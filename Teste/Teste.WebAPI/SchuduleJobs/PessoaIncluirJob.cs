using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Application.Interfaces;
using Teste.Infra.CrossCutting.JobConfiguration.Entities;

namespace Teste.WebAPI.SchuduleJobs
{
    public class PessoaIncluirJob : IJob
    {
        private readonly IJobConfigurationApp jobConfigurationApp;

        public PessoaIncluirJob(IJobConfigurationApp jobConfigurarionApp)
        {
            this.jobConfigurationApp = jobConfigurarionApp;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var request = new StandardJobRequest();
            request.JobType = JobTypeLogEnum.JobCreate;

            jobConfigurationApp.DefaultJobExecution(request);

            return Task.CompletedTask;
            
        }
    }
}
