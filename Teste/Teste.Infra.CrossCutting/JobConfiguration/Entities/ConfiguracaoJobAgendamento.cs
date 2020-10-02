using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Infra.CrossCutting.JobConfiguration.Entities
{
    public class ConfiguracaoJobAgendamento
    {
        public int Id { get; set; }
        public int? ConfiguracaoJobId { get; set; }
        public TimeSpan HorarioAgendamento { get; set; }

        public ConfiguracaoJob ConfiguracaoJob { get; set; }
    }
}
