using System.Web.Http;
using Castle.Windsor;
using Castle.Windsor.Installer;
using MrmTechTest.Core.Infrastructure.Windsor;

namespace MrmTechTest
{
    public class WindsorConfig
    {
        public static void Configure()
        {
            var container = new WindsorContainer();
            container.Install(FromAssembly.This());
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(container.Kernel);
        }
    }
}