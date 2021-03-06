﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.MicroKernel;
using IDependencyResolver = System.Web.Http.Dependencies.IDependencyResolver;

namespace MrmTechTest.Core.Infrastructure.Windsor
{
    internal class WindsorDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public WindsorDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        public virtual IDependencyScope BeginScope() => new WindsorDependencyScope(_kernel);

        public virtual object GetService(Type serviceType)
            => _kernel.HasComponent(serviceType) ? _kernel.Resolve(serviceType) : null;

        public virtual IEnumerable<object> GetServices(Type serviceType) => _kernel.ResolveAll(serviceType).Cast<object>();

        public virtual void Dispose()
        {
        }
    }
}