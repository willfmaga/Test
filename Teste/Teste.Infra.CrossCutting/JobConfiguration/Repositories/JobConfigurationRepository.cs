using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste.Infra.CrossCutting.JobConfiguration.Entities;
using Teste.Infra.CrossCutting.JobConfiguration.Repositories.Interface;

namespace Teste.Infra.CrossCutting.JobConfiguration.Repositories
{
    public class JobConfigurationRepository :BaseRepository<ConfiguracaoJob>, IJobConfigurationRepository
    {
        public JobConfigurationRepository(JobConfigurationContexto contexto): base(contexto)
        {
                
        }
        public List<ConfiguracaoJob> GetAll()
        {
            return dbSetConfiguracaoJob.Include(t => t.Agendamentos).ToList();
        }
    }
}
