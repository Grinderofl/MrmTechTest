using System.Data.Entity;

namespace MrmTechTest.Core.Infrastructure.Queries
{
    public abstract class QueryObject<TResult>
    {
        public abstract TResult Execute(DbContext context);
    }
}