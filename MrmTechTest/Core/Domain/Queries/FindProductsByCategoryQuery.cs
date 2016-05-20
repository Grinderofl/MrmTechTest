using System.Data.Entity;
using System.Linq;
using MrmTechTest.Core.Infrastructure.Queries;

namespace MrmTechTest.Core.Domain.Queries
{
    public class FindProductsByCategoryQuery : QueryObject<IQueryable<Product>>
    {
        private readonly Category _category;

        public FindProductsByCategoryQuery(Category category)
        {
            _category = category;
        }

        public override IQueryable<Product> Execute(DbContext context)
        {
            return context.Set<Product>().Where(x => x.Category.Id == _category.Id);
        }
    }
}