using CardsAgainstHumanity.Interfaces;
using CardsAgainstHumanity.Models;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardsAgainstHumanity.Installers
{
    public class GameInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Adds the HTTP controllers to the container.
        /// </summary>
        /// <param name="container">The container to configure.</param>
        /// <param name="store">The configuration store to use.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "This is handled by the framework")]
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IGetCard)).ImplementedBy(typeof(GetCard)).LifestyleSingleton());
            container.Register(Component.For(typeof (ICardResolver)).ImplementedBy(typeof (CardResolver)).LifestyleSingleton());
            container.Register(Component.For(typeof (IGame)).ImplementedBy(typeof(Game)).LifestyleSingleton());
        }
    }
}