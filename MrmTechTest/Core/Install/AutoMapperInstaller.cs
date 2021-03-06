using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace MrmTechTest.Core.Install
{
    public class AutoMapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Mapper.Initialize(conf =>
            {
                conf.ConstructServicesUsing(container.Resolve);
                var childContainer = new WindsorContainer();
                container.AddChildContainer(childContainer);
                childContainer.Register(Classes.FromThisAssembly().BasedOn<Profile>().WithServiceBase());
                foreach (var profile in childContainer.ResolveAll<Profile>())
                    conf.AddProfile(profile);
                container.RemoveChildContainer(childContainer);
                container.Register(Component.For<IMapper>().Instance(Mapper.Instance),
                    Component.For<IConfigurationProvider>().Instance(Mapper.Engine.ConfigurationProvider));
            });

            container.Register(
                Classes.FromThisAssembly().BasedOn(typeof (ITypeConverter<,>)),
                Classes.FromThisAssembly().BasedOn(typeof (IMappingAction<,>)),
                Classes.FromThisAssembly().BasedOn<IValueResolver>());
        }
    }
}