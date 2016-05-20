using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MrmTechTest.Areas.Api.Factories;
using MrmTechTest.Areas.Api.Models.Products;
using MrmTechTest.Core.Domain;
using MrmTechTest.Core.Domain.Queries;
using MrmTechTest.Core.Infrastructure.EntityFramework;

namespace MrmTechTest.Areas.Api.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IRepository _repository;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IProductFactory _productFactory;
        private readonly IMapper _mapper;

        public ProductsController(IRepository dbContext, IConfigurationProvider configurationProvider, IProductFactory productFactory, IMapper mapper)
        {
            _repository = dbContext;
            _configurationProvider = configurationProvider;
            _productFactory = productFactory;
            _mapper = mapper;
        }

        // GET: /api/products
        public IEnumerable<ProductLineItem> Get()
        {
            var products = _repository.Query(new FindAllProductsQuery());
            return products.ProjectToList<ProductLineItem>(_configurationProvider);
        }

        // DELETE: /api/products/{id}
        public void Delete(long id)
        {
            var product = _repository.Find<Product>(id);
            if(product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _repository.Delete(product);
        }

        // POST: /api/products
        public ProductLineItem Post(ProductFields fields)
        {
            var product = _productFactory.Create(fields);
            _repository.Save(product);
            return _mapper.Map<ProductLineItem>(product);
        }
    }
}