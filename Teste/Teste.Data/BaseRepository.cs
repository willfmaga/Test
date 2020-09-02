using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Data
{
    public class BaseRepository<T> where T : class
    {
        protected readonly RepomVisaCampanhaContexto contexto;
        protected readonly Microsoft.EntityFrameworkCore.DbSet<T> dbSet;

        public BaseRepository(RepomVisaCampanhaContexto contexto)
        {
            this.contexto = contexto;
            this.dbSet = contexto.Set<T>();
        }
    }
}
