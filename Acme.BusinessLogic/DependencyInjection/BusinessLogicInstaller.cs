using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Acme.BusinessLogic.DependencyInjection
{
    public class BusinessLogicInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .Pick().If(t => t.Name.EndsWith("Service"))
                .WithService.DefaultInterfaces()
                .Configure(configurer => configurer.Named(configurer.Implementation.Name)));
            
            container.Register(Classes.FromThisAssembly()
                .Pick().If(t => t.Name.EndsWith("Provider"))
                .WithService.DefaultInterfaces()
                .Configure(configurer => configurer.Named(configurer.Implementation.Name)));
        }
    }
}