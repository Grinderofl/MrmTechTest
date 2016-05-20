using AutoMapper;
using Moq;
using MrmTechTest.Areas.Api.Controllers;
using MrmTechTest.Areas.Api.Factories;
using MrmTechTest.Areas.Api.Mapping;

namespace MrmTechTest.Tests
{
    public abstract class ProductContext : WebApiTestBase
    {
        protected ProductsController ProductsController;
        protected Mock<IProductFactory> ProductFactory;

        protected override void SharedContext()
        {
            ProductFactory = CreateDependency<IProductFactory>();
            ProductsController = new ProductsController(RepositoryMock.Object, ConfigurationProvider,
                ProductFactory.Object, Automapper);
        }

        protected override void ConfigureAutoMapper(IMapperConfiguration mapperConfiguration)
        {
            mapperConfiguration.AddProfile<ProductProfile>();
        }
    }
}