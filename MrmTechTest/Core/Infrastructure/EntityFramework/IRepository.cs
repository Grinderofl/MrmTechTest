using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MrmTechTest.Core.Infrastructure.Queries;

namespace MrmTechTest.Core.Infrastructure.EntityFramework
{
    public interface IRepository
    {
        TEntity Find<TEntity>(object id) where TEntity : class;
        TResult Query<TResult>(QueryObject<TResult> query);
        void Delete<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Saves an entity to repository
        /// </summary>
        /// <remarks>
        /// Normally there would be a unit of work going through the pipeline
        /// which handles saving actual changes. Here, we just treat each repository save
        /// as a single unit of work, due to the simplicity of the application.
        /// </remarks>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void Save<TEntity>(TEntity entity) where TEntity : class;
    }
}
