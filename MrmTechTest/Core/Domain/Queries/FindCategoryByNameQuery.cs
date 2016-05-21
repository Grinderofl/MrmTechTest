using System.Data.Entity;
using System.Linq;
using MrmTechTest.Core.Infrastructure.Queries;

namespace MrmTechTest.Core.Domain.Queries
{
    public class FindCategoryByNameQuery : QueryObject<Category>
    {
        internal readonly string Name;

        public FindCategoryByNameQuery(string name)
        {
            Name = name;
        }

        public override Category Execute(DbContext context)
        {
            return context.Set<Category>().FirstOrDefault(x => x.Name == Name);
        }
    }
}