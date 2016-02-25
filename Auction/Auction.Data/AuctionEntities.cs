using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public virtual DbSet<AuctionStatus> AuctionStatuses { get; set; }
        public virtual DbSet<Bid> Bids { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal StartingPrice { get; set; }
        public decimal Estimate { get; set; }
        public decimal MinimumBidAmount { get; set; }
        public decimal NextMinimumBid { get; set; }
        public ItemStatus ItemStatus { get; set; }
        public Bid HighestBid { get; set; }
        public List<Bid> Bids { get; set; }

    }

    public class Auction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AuctionDate { get; set; }
        public AuctionStatus AuctionStatus { get; set; }
        public List<Item> Items { get; set; }
    }

    public class AuctionStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ItemStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Bid
    {
        public int Id { get; set; }
        public Decimal CommitToBid { get; set; }
        public int UserId { get; set; } //TODO
        [NotMapped]
        public bool IsHighestBid { get; set; }
    }
}