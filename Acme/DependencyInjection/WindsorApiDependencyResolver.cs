using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Acme.BusinessLogic.DependencyInjection;
using Castle.MicroKernel.Lifestyle;

namespace Acme.DependencyInjection
{
    public class WindsorApiDependencyResolver : IDependencyResolver
    {
        private IDisposable _scope;

        public void Dispose()
        {
            _scope.Dispose();
        }

        public object GetService(Type serviceType)
        {
            return Acme.BusinessLogic.DependencyInjection.Container.Instance.Kernel.HasComponent(serviceType) 
                ? Container.Instance.Resolve(serviceType) 
                : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Container.Instance.ResolveAll(serviceType).Cast<object>();
        }

        public IDependencyScope BeginScope()
        {
            _scope = Container.Instance.BeginScope();
            
            return new DependencyScope();
        }
    }
}