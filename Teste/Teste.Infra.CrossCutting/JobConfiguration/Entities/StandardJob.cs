using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Infra.CrossCutting.JobConfiguration.Entities
{
    public class StandardJobRequest
    {
        public JobTypeLogEnum JobType { get; set; }
    }
    public interface IJobRequest
    {
        JobTypeLogEnum JobType { get; set; }
    }

    public class StandardJobResponse
    {
        public StatusJobLogEnum StatusJobLogEnum { get; set; }

        public string Descricao { get; set; }
    }

    public enum JobTypeLogEnum
    {
        JobCreate
    }

    public enum StatusJobLogEnum
    {
        JobExecutadoComSucesso = 1,
        JobExecutadoComErro = 2
    }
}
