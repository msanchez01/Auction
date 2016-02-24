using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Bid CommitToBid(int itemId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
