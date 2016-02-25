namespace Auction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuctionStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AuctionDate = c.DateTime(nullable: false),
                        AuctionStatus_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuctionStatus", t => t.AuctionStatus_Id)
                .Index(t => t.AuctionStatus_Id);
            
            CreateTable(
                "dbo.AuctionStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        StartingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estimate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinimumBidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NextMinimumBid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HighestBid_Id = c.Int(),
                        ItemStatus_Id = c.Int(),
                        Auction_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bids", t => t.HighestBid_Id)
                .ForeignKey("dbo.ItemStatus", t => t.ItemStatus_Id)
                .ForeignKey("dbo.Auctions", t => t.Auction_Id)
                .Index(t => t.HighestBid_Id)
                .Index(t => t.ItemStatus_Id)
                .Index(t => t.Auction_Id);
            
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommitToBid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ItemStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Auction_Id", "dbo.Auctions");
            DropForeignKey("dbo.Items", "ItemStatus_Id", "dbo.ItemStatus");
            DropForeignKey("dbo.Items", "HighestBid_Id", "dbo.Bids");
            DropForeignKey("dbo.Bids", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.Auctions", "AuctionStatus_Id", "dbo.AuctionStatus");
            DropIndex("dbo.Bids", new[] { "Item_Id" });
            DropIndex("dbo.Items", new[] { "Auction_Id" });
            DropIndex("dbo.Items", new[] { "ItemStatus_Id" });
            DropIndex("dbo.Items", new[] { "HighestBid_Id" });
            DropIndex("dbo.Auctions", new[] { "AuctionStatus_Id" });
            DropTable("dbo.ItemStatus");
            DropTable("dbo.Bids");
            DropTable("dbo.Items");
            DropTable("dbo.Auctions");
        }
    }
}
