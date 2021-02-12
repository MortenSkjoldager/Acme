using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Acme.BusinessLogic.DependencyInjection;

namespace Acme.DependencyInjection
{
    public class DependencyScope : IDependencyScope
    {
        public DependencyScope()
        {
            
        }
        
        public void Dispose()
        {
            
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
    }
}