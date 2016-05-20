using AutoMapper;
using MrmTechTest.Areas.Api.Controllers;
using MrmTechTest.Areas.Api.Mapping;

namespace MrmTechTest.Tests
{
    public abstract class CategoryProductsContext : WebApiTestBase
    {
        protected CategoryProductsController Controller;

        protected override void SharedContext()
        {
            Controller = new CategoryProductsController(RepositoryMock.Object, ConfigurationProvider);
        }

        protected override void ConfigureAutoMapper(IMapperConfiguration mapperConfiguration)
        {
            mapperConfiguration.AddProfile<ProductProfile>();
        }
    }
}