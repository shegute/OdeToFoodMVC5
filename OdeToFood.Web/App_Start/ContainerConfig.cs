using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Ajax.Utilities;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web
{
    //??? Added this new class to configure the DI container configuration.
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            //??? Register all controllers in the assembly.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //??? Register all InMemRestData as the type for interface IRestauratnData
            builder.RegisterType<InMemoryRestaurantData>()
                .As<IRestaurantData>()
                .SingleInstance();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    } }
}