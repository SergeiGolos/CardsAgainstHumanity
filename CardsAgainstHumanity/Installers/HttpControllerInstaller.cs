using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Http.Controllers;
using System.Web.Mvc;
namespace CardsAgainstHumanity.Installers
{
    /// <summary>
    /// Registers the HTTP controllers with the container.
    /// </summary>
    public class HttpControllerInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Adds the HTTP controllers to the container.
        /// </summary>
        /// <param name="container">The container to configure.</param>
        /// <param name="store">The configuration store to use.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "This is handled by the framework")]
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient());
            container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());
        }
    }
}