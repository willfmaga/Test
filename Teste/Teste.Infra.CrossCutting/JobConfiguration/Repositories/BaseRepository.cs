using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste.Infra.CrossCutting.JobConfiguration.Entities;

namespace Teste.Infra.CrossCutting.JobConfiguration.Repositories
{
    public class BaseRepository<T> where T : class
    {
        private JobConfigurationContexto contexto;
        internal readonly DbSet<ConfiguracaoJob> dbSetConfiguracaoJob;
        internal readonly DbSet<ConfiguracaoJobAgendamento> dbSetConfiguracaoJobAgendamento;

        public BaseRepository(JobConfigurationContexto contexto)
        {
            this.contexto = contexto;
            this.dbSetConfiguracaoJob = contexto.Set<ConfiguracaoJob>();
            this.dbSetConfiguracaoJobAgendamento = contexto.Set<ConfiguracaoJobAgendamento>();
        }
    }
}
