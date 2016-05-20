using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using AutoMapper;
using MrmTechTest.Areas.Api.Factories;
using MrmTechTest.Areas.Api.Models.Products;
using MrmTechTest.Core.Domain;
using MrmTechTest.Core.Domain.Queries;
using MrmTechTest.Core.Infrastructure.EntityFramework;

namespace MrmTechTest.Areas.Api.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IMapper _mapper;
        private readonly IProductFactory _productFactory;
        private readonly IRepository _repository;

        public ProductsController(IRepository dbContext, IConfigurationProvider configurationProvider,
            IProductFactory productFactory, IMapper mapper)
        {
            _repository = dbContext;
            _configurationProvider = configurationProvider;
            _productFactory = productFactory;
            _mapper = mapper;
        }

        // GET: /api/products
        /// <summary>
        /// Retrieves all available products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductLineItem> Get()
        {
            var products = _repository.Query(new FindAllProductsQuery());
            return products.ProjectToList<ProductLineItem>(_configurationProvider);
        }

        // DELETE: /api/products/{id}
        /// <summary>
        /// Deletes a product from the system
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            var product = _repository.Find<Product>(id);
            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _repository.Delete(product);
        }

        // POST: /api/products
        /// <summary>
        /// Creates a new product (and category, if required)
        /// </summary>
        /// <param name="fields">Fields to use</param>
        /// <returns></returns>
        public ProductLineItem Post(ProductFields fields)
        {
            var product = _productFactory.Create(fields);
            _repository.Save(product);
            return _mapper.Map<ProductLineItem>(product);
        }
    }
}