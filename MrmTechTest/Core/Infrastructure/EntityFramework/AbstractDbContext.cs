using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using MrmTechTest.Core.Domain.Base;
using MrmTechTest.Core.Infrastructure.Queries;

namespace MrmTechTest.Core.Infrastructure.EntityFramework
{
    public abstract class AbstractDbContext : DbContext, IRepository
    {
        protected AbstractDbContext()
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public virtual TEntity Find<TEntity>(object id) where TEntity : class
        {
            return Set<TEntity>().Find(id);
        }

        public virtual TResult Query<TResult>(QueryObject<TResult> query)
        {
            return query.Execute(this);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            Set<TEntity>().Remove(entity);
            SaveChanges();
        }

        public void Save<TEntity>(TEntity entity) where TEntity : class
        {
            Set<TEntity>().Add(entity);
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var entityTypes =
                Assembly.GetExecutingAssembly()
                    .GetExportedTypes()
                    .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof (Entity)));
            foreach (var entityType in entityTypes)
            {
                modelBuilder.RegisterEntityType(entityType);
            }

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (
                var entity in
                    ChangeTracker.Entries()
                        .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                        .Select(x => x.Entity)
                        .OfType<Entity>())
            {
                entity.LastModified = DateTime.Now;
            }
            return base.SaveChanges();
        }
    }
}