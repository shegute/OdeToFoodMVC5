using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Ajax.Utilities;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OdeToFood.Web
{
    //??? Added this new class to configure the DI container configuration.
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            //??? Register all controllers in the assembly.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //??? Modified bc we are working with two different frameworks; MVC FW and WebApi FW.
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            //??? Register InMemoryRestaurantData as the type for interface IRestaurantData
            //builder.RegisterType<InMemoryRestaurantData>()
            //    .As<IRestaurantData>()
            //    .SingleInstance();
            //??? Register all SqlRestaurantData as the type for interface IRestaurantData
            builder.RegisterType<SqlRestaurantData>()
                .As<IRestaurantData>()
                .InstancePerRequest();
            builder.RegisterType<OdeToFoodDbContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //??? Modified bc we are working with two different frameworks; MVC FW and WebApi FW.
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}