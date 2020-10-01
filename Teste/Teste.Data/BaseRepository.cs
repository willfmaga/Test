using System;
using System.Collections.Generic;
using System.Text;
using Teste.Domain.Entities;

namespace Teste.Data
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected readonly RepomVisaCampanhaContexto contexto;
        protected readonly Microsoft.EntityFrameworkCore.DbSet<T> dbSet;

        public BaseRepository(RepomVisaCampanhaContexto contexto)
        {
            this.contexto = contexto;
            this.dbSet = contexto.Set<T>();
        }

        public T GetById(Int64 id)
        {
            return dbSet.Find(id);
        }

        public Int64 Add(T entity)
        {
            dbSet.Add(entity);

            contexto.SaveChanges();

            return entity.Id;
        }
    }
}
