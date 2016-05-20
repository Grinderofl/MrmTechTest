using System.Data.Entity;
using System.Linq;
using MrmTechTest.Core.Infrastructure.Queries;

namespace MrmTechTest.Core.Domain.Queries
{
    public class FindAllCategoriesQuery : QueryObject<IQueryable<Category>>
    {
        public override IQueryable<Category> Execute(DbContext context)
        {
            return context.Set<Category>();
        }
    }
}