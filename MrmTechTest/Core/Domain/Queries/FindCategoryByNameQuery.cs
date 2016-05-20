using System.Data.Entity;
using System.Linq;
using MrmTechTest.Core.Infrastructure.Queries;

namespace MrmTechTest.Core.Domain.Queries
{
    public class FindCategoryByNameQuery : QueryObject<Category>
    {
        private readonly string _name;

        public FindCategoryByNameQuery(string name)
        {
            _name = name;
        }

        public override Category Execute(DbContext context)
        {
            return context.Set<Category>().FirstOrDefault(x => x.Name == _name);
        }
    }
}