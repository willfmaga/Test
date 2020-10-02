using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using Teste.Application.Interfaces;
using Teste.Domain.Entities;
using Teste.Domain.Interface.Services;
using Teste.Infra.CrossCutting.JobConfiguration.Entities;
using Teste.Infra.CrossCutting.JobConfiguration.Services.Interfaces;

namespace Teste.Application.Services
{
    public class JobConfigurationApp : IJobConfigurationApp
    {
        private readonly IJobConfigurationService jobConfigurationService;
        private readonly IPessoaService pessoaService;

        public JobConfigurationApp(IJobConfigurationService jobConfigurationService, IPessoaService pessoaService)
        {
            this.jobConfigurationService = jobConfigurationService;
            this.pessoaService = pessoaService;
        }

        public StandardJobResponse DefaultJobExecution(StandardJobRequest request)
        {
            var response = new StandardJobResponse();

            switch (request.JobType)
            {
                case JobTypeLogEnum.JobCreate:
                    pessoaService.Incluir(new Pessoa() { Nome = "William", Sobrenome = "Maga", veiculos = new List<Veiculo>() { new Veiculo() { Placa = "ird7998" } } });
                    break;
                default:
                    response.StatusJobLogEnum = StatusJobLogEnum.JobExecutadoComErro;
                    response.Descricao = $"Tipo job nao configurado - {request.JobType.ToString()}";
                    break;
            }

            return response;
        }
    }
}
