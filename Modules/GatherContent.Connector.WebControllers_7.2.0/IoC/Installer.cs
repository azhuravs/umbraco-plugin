using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace GatherContent.Connector.WebControllers_7._2._0.IoC
{
    /// <summary>
    /// 
    /// </summary>
    public class Installer : IWindsorInstaller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        /// <param name="store"></param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .BasedOn<ApiController>()
                .LifestyleTransient()
                );

            //container.Register(Classes.FromThisAssembly()
            //    .BasedOn<TreeController>()
            //    .LifestyleTransient()
            //    );

            GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(container);
        }
    }
}