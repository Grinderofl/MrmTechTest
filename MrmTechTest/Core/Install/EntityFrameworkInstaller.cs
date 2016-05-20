using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MrmTechTest.Core.EntityFramework;
using MrmTechTest.Core.Infrastructure.EntityFramework;

namespace MrmTechTest.Core.Install
{
    public class EntityFrameworkInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IRepository>().ImplementedBy<ApplicationDbContext>().LifestyleScoped());
        }
    }
}