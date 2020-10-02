using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Infra.CrossCutting.JobConfiguration.Entities
{
    public class ConfiguracaoJob
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int IntervaloExecucaoTipoId { get; set; }
        public int? IntervaloExecucao { get; set; }
        public int StatusId { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public List<ConfiguracaoJobAgendamento> Agendamentos { get; set; }

        public enum StatusConfiguracaoJobEnum
        {
            JobAtivo = 1,
            JobParado = 2
        }

        public TipoIntervaloExecucaoJobEnum TipoIntervaloExecucaoEnum
        {
            get
            {
                return (TipoIntervaloExecucaoJobEnum)IntervaloExecucaoTipoId;
            }
        }


        public enum TipoIntervaloExecucaoJobEnum
        {
            IntervaloExecucaoSegundo = 3,
            IntervaloExecucaoMinuto = 4,
            IntervaloExecucaoHora = 5,
            IntervaloExecucaoDia = 6,
            IntervaloExecucaoAgendado = 7
        }


        public StatusConfiguracaoJobEnum StatusEnum
        {
            get
            {
                return (StatusConfiguracaoJobEnum)StatusId;
            }
        }
    }


}
