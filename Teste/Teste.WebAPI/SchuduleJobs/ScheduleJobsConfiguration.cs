using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Teste.Infra.CrossCutting.JobConfiguration.Entities;
using Teste.Infra.CrossCutting.JobConfiguration.Services.Interfaces;
using static Teste.Infra.CrossCutting.JobConfiguration.Entities.ConfiguracaoJob;

namespace Teste.WebAPI.SchuduleJobs
{
    public class ScheduleJobsConfiguration
    {
        private static IJobConfigurationService _jobConfigurationService;

        public ScheduleJobsConfiguration(IJobConfigurationService jobConfigurationService)
        {
            _jobConfigurationService = jobConfigurationService;
        }


        public void ScheduleJobs(IScheduler scheduler)
        {
            var configuracoesJobs = _jobConfigurationService.GetAll();

            if (configuracoesJobs != null)
                configuracoesJobs = configuracoesJobs.Where(x => x.StatusEnum == StatusConfiguracaoJobEnum.JobAtivo).ToList();

            foreach (var config in configuracoesJobs)
            {
                //cron Expression
                //site gerador freeformatter.com/cron-expression-generator-quartz.html
                List<string> cronExpressions = new List<string>();

                switch (config.TipoIntervaloExecucaoEnum)
                {
                    case TipoIntervaloExecucaoJobEnum.IntervaloExecucaoSegundo:
                        cronExpressions.Add(string.Format("0/{0} * * ? * * *", config.IntervaloExecucao.ToString()));
                        break;
                    case TipoIntervaloExecucaoJobEnum.IntervaloExecucaoMinuto:
                        cronExpressions.Add(string.Format("0 0/{0} * ? * * *", config.IntervaloExecucao.ToString()));
                        break;
                    case TipoIntervaloExecucaoJobEnum.IntervaloExecucaoHora:
                        cronExpressions.Add(string.Format("0 0 0/{0} ? * * *", config.IntervaloExecucao.ToString()));
                        break;
                    case TipoIntervaloExecucaoJobEnum.IntervaloExecucaoDia:
                        cronExpressions.Add(string.Format("0 0 0 1/{0} * ? *", config.IntervaloExecucao));
                        break;
                    case TipoIntervaloExecucaoJobEnum.IntervaloExecucaoAgendado:

                        foreach (ConfiguracaoJobAgendamento agendamento in config.Agendamentos)
                            cronExpressions.Add(string.Format("0 {0} {1} ? * * *", agendamento.HorarioAgendamento.Minutes, agendamento.HorarioAgendamento.Hours));
                        break;
                }

                int count = 0;
                foreach (var cronExpression in cronExpressions)
                {
                    var type = Type.GetType(string.Format(MethodBase.GetCurrentMethod().DeclaringType.Namespace + ".{0}", config.Nome));
                    if (type != null)
                    {
                        count++;
                        IJobDetail job = JobBuilder.Create()
                            .WithIdentity(config.Nome + "Job" + count.ToString(), config.Nome + "Group")
                            .OfType(type)
                            .Build();

                        // Trigger para que o job seja executado imediatamente, e repetidamente a cada 15 segundos
                        ITrigger trigger = TriggerBuilder.Create()
                          .WithIdentity(config.Nome + "Trigger" + count.ToString(), config.Nome + "Group")
                          .StartNow()
                          .WithCronSchedule(cronExpression)
                          .Build();

                        scheduler.ScheduleJob(job, trigger).Wait();
                    }
                }
            }
        }
    }
}
