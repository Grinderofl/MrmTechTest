using AutoMapper;
using MrmTechTest.Areas.Api.Controllers;
using MrmTechTest.Areas.Api.Mapping;

namespace MrmTechTest.Tests
{
    public abstract class CategoryContext : WebApiTestBase
    {
        protected CategoriesController CategoriesController;

        protected override void SharedContext()
        {
            CategoriesController = new CategoriesController(RepositoryMock.Object, ConfigurationProvider);
        }

        protected override void ConfigureAutoMapper(IMapperConfiguration mapperConfiguration)
        {
            mapperConfiguration.AddProfile<CategoryProfile>();
        }
    }
}