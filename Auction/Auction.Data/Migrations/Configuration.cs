namespace Auction.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AuctionEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuctionEntities context)
        {
            context.AuctionStatuses.AddOrUpdate(
                new AuctionStatus {Name = "Pending"},
                new AuctionStatus {Name = "In Progress"},
                new AuctionStatus {Name = "Finsihed"});
        }
    }
}
