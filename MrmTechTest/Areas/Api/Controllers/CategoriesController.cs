using System.Linq;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MrmTechTest.Areas.Api.Models.Categories;
using MrmTechTest.Core.Domain.Queries;
using MrmTechTest.Core.Infrastructure.EntityFramework;

namespace MrmTechTest.Areas.Api.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IRepository _repository;

        public CategoriesController(IRepository dbContext, IConfigurationProvider configurationProvider)
        {
            _repository = dbContext;
            _configurationProvider = configurationProvider;
        }

        // GET: /api/categories
        // Returns IQueryable to allow further filtering as passed in through the OData parameters
        /// <summary>
        /// Retrieves a queryable list of categories
        /// </summary>
        /// <returns></returns>
        public IQueryable<CategoryLineItem> Get()
        {
            var categories = _repository.Query(new FindAllCategoriesQuery());
            return categories.ProjectTo<CategoryLineItem>(_configurationProvider);
        }
    }
}