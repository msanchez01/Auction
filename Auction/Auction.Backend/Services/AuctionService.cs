using System.Collections.Generic;
using System.Linq;
using Auction.Data;

namespace Auction.Backend.Services
{
    public class AuctionService : IAuctionService
    {
        public AuctionService(AuctionEntities auctionEntities)
        {
            _auctionEntities = auctionEntities;
        }

        public AuctionService()
        {
        }

        private readonly AuctionEntities _auctionEntities;
        public List<Data.Auction> GetAllAuctions()
        {
            var auctions = _auctionEntities.Auctions.ToList();
            return auctions;
        }

        public Data.Auction GetAuctionById(int auctionId)
        {
            var auction = _auctionEntities.Auctions.FirstOrDefault(x => x.Id == auctionId);
            return auction;
        }

        public List<Item> GetItemsByAuction(int auctionId)
        {
            var auction = _auctionEntities.Auctions.FirstOrDefault(x => x.Id == auctionId);
            return auction?.Items;
        }

        public Item GetItemByItemId(int itemId)
        {
            var item = _auctionEntities.Items.FirstOrDefault(x => x.Id == itemId);
            return item;
        }

        public List<Bid> GetBidsByItemId(int itemId)
        {
            var item = _auctionEntities.Items.FirstOrDefault(x => x.Id == itemId);
            return item?.Bids;
        }

        public Bid CommitToBid(Bid bid, int itemId)
        {
            var item = _auctionEntities.Items.FirstOrDefault(x => x.Id == itemId);
            if (item == null) return null; // TODO: Return meaningful message

            _auctionEntities.Bids.Add(bid);
            item.Bids.Add(bid);
            
            if (item.HighestBid == null || item.HighestBid.CommitToBid <= bid.CommitToBid)
            {
                item.HighestBid = bid;
            }
            _auctionEntities.SaveChanges();

            return bid;
        }
    }
}
