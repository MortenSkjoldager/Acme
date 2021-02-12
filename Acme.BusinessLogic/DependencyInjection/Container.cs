using System;
using System.Linq;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Acme.BusinessLogic.DependencyInjection
{ 
	/// <summary>
	/// Wrapper for Dependency Injection Container / IOC Container implemented by Castle Windsor
	/// </summary>
	public static class Container
    {
		private static IWindsorContainer _container;

		private static object _padlock = new object();

		public static IWindsorContainer Instance => _container;
		
		public static void Initialize()
		{
			if (_container == null)
			{
				lock (_padlock)
				{
					if (_container == null)
					{
						_container = new WindsorContainer();
						
						//Let each project/assembly register their own dependencies.
						foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("Acme")))
						{
							_container.Install(FromAssembly.Named(assembly.FullName));
						}
					}
				}
			}
		}
    }
}
