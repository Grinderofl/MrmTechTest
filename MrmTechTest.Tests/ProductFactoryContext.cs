using Moq;
using MrmTechTest.Areas.Api.Factories.Impl;
using MrmTechTest.Core.Infrastructure.EntityFramework;

namespace MrmTechTest.Tests
{
    public abstract class ProductFactoryContext : TestBase
    {
        protected ProductFactory ProductFactory;
        protected Mock<IRepository> RepositoryMock;
        protected override void SharedContext()
        {
            RepositoryMock = CreateDependency<IRepository>();
            ProductFactory = new ProductFactory(RepositoryMock.Object);
        }
    }
}