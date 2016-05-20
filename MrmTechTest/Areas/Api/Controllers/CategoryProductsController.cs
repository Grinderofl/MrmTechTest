using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MrmTechTest.Areas.Api.Models.Products;
using MrmTechTest.Core.Domain;
using MrmTechTest.Core.Domain.Queries;
using MrmTechTest.Core.Infrastructure.EntityFramework;

namespace MrmTechTest.Areas.Api.Controllers
{
    public class CategoryProductsController : ApiController
    {
        private readonly IRepository _repository;
        private readonly IConfigurationProvider _configurationProvider;

        public CategoryProductsController(IRepository dbContext, IConfigurationProvider configurationProvider)
        {
            _repository = dbContext;
            _configurationProvider = configurationProvider;
        }

        // GET: /api/categories/{id}/products
        public IEnumerable<ProductLineItem> Get(long id)
        {
            var category = _repository.Find<Category>(id);
            if (category == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            var products = _repository.Query(new FindProductsByCategoryQuery(category));
            return products.ProjectToList<ProductLineItem>(_configurationProvider);
        }
    }
}