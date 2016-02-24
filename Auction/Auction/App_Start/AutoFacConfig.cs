using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;
using Auction.Backend;
using Auction.Backend.Services;
using Auction.Data;
using Autofac;
using Autofac.Integration.Mvc;

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

            var container = builder.Build();

            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }
    }

    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            /*builder.Register(c => new AuctionService())
                .As<IAuctionService>()
                .InstancePerLifetimeScope();*/
            builder.RegisterType<AuctionService>()
           .As<IAuctionService>()
           .WithParameter("auctionEntities", new AuctionEntities());
        }
    }
}