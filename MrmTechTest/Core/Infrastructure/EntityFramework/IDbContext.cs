using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MrmTechTest.Core.Infrastructure.Queries;

namespace MrmTechTest.Core.Infrastructure.EntityFramework
{
    public interface IDbContext
    {
        TEntity Find<TEntity>(object id) where TEntity : class;
        TResult Query<TResult>(QueryObject<TResult> query);
        int Save();
    }
}
