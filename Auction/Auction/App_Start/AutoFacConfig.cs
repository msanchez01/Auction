using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Http;
using System.Web.Mvc;
using Auction.Backend;
using Auction.Backend.Services;
using Auction.Data;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Module = Autofac.Module;

namespace Auction.App_Start
{


    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new AutofacModule());
            builder.RegisterModule(new BackendAutoFacModule());

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); 

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); 
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
           
        }
    }

    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            /*builder.Register(c => new AuctionService( new AuctionEntities()))
                .As<IAuctionService>()
                .InstancePerLifetimeScope();*/
            builder.RegisterType<AuctionService>()
           .As<IAuctionService>()
           .WithParameter("auctionEntities", new AuctionEntities());
        }
    }
}