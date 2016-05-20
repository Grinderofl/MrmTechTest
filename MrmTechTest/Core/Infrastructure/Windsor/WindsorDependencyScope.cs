using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;

namespace MrmTechTest.Core.Infrastructure.Windsor
{
    public class WindsorDependencyScope : IDependencyScope
    {
        private readonly IKernel _container;
        private readonly IDisposable _scope;

        public WindsorDependencyScope(IKernel container)
        {
            _container = container;
            _scope = container.BeginScope();
        }

        public virtual object GetService(Type serviceType)
            => _container.HasComponent(serviceType) ? _container.Resolve(serviceType) : null;

        public virtual IEnumerable<object> GetServices(Type serviceType) => _container.ResolveAll(serviceType).Cast<object>();

        public void Dispose() => _scope.Dispose();
    }
}