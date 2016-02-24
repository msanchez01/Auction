using System.Collections.Generic;

namespace Auction.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AuctionEntities : DbContext, IDbContext
    {
        // Your context has been configured to use a 'AuctionEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Auction.Data.AuctionEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AuctionEntities' 
        // connection string in the application configuration file.
        public AuctionEntities()
            : base("name=AuctionEntities")
        {
        }
       
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Auction> Auctions { get; set; }
        public virtual DbSet<Bid> Bids { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal StartingPrice { get; set; }
        public Decimal Estimate { get; set; }
        public List<Bid> Bids { get; set; }

    }

    public class Auction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AuctionDate { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Bid
    {
        public int Id { get; set; }
        public Decimal CommitToBid { get; set; }
        public int UserId { get; set; } //TODO
    }
}