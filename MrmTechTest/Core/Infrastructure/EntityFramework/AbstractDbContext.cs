using System;
using System.Data.Entity;
using MrmTechTest.Core.Infrastructure.Queries;

namespace MrmTechTest.Core.Infrastructure.EntityFramework
{
    public abstract class AbstractDbContext : DbContext, IDbContext
    {
        public TEntity Find<TEntity>(object id) where TEntity : class
        {
            return Set<TEntity>().Find(id);
        }

        public TResult Query<TResult>(QueryObject<TResult> query)
        {
            return query.Execute(this);
        }

        public int Save()
        {
            return SaveChanges();
        }
    }
}