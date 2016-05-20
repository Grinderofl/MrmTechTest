using AutoMapper;
using Moq;
using MrmTechTest.Core.Infrastructure.EntityFramework;

namespace MrmTechTest.Tests
{
    public abstract class WebApiTestBase : TestBase
    {
        protected IConfigurationProvider ConfigurationProvider;
        protected IMapper Automapper;

        protected Mock<IRepository> RepositoryMock;

        public override void Setup()
        {
            Mapper.Initialize(ConfigureAutoMapper);
            ConfigurationProvider = Mapper.Engine.ConfigurationProvider;
            Automapper = Mapper.Instance;
            RepositoryMock = CreateDependency<IRepository>();
            base.Setup();
        }

        protected virtual void ConfigureAutoMapper(IMapperConfiguration mapperConfiguration)
        { }
    }
}