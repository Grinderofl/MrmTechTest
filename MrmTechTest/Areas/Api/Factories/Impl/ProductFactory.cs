using MrmTechTest.Areas.Api.Models.Products;
using MrmTechTest.Core.Domain;
using MrmTechTest.Core.Domain.Queries;
using MrmTechTest.Core.Infrastructure.EntityFramework;

namespace MrmTechTest.Areas.Api.Factories.Impl
{
    public class ProductFactory : IProductFactory
    {
        private readonly IRepository _repository;

        public ProductFactory(IRepository repository)
        {
            _repository = repository;
        }

        public Product Create(ProductFields fields)
        {
            var product = new Product(fields.Name, fields.Description);
            var category = _repository.Query(new FindCategoryByNameQuery(fields.Category)) ??
                           new Category(fields.Category);
            product.AssignTo(category);
            return product;
        }
    }
}