using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Backend.Services;
using Auction.Data;
using Autofac;

namespace Auction.Backend
{
    public class BackendAutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<AuctionEntities>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
