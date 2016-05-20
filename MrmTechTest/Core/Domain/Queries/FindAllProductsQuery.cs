using System.Data.Entity;
using System.Linq;
using MrmTechTest.Core.Infrastructure.Queries;

namespace MrmTechTest.Core.Domain.Queries
{
    public class FindAllProductsQuery : QueryObject<IQueryable<Product>>
    {
        public override IQueryable<Product> Execute(DbContext context)
        {
            return context.Set<Product>();
        }
    }
}