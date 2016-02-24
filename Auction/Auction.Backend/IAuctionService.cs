using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Data;

namespace Auction.Backend
{
    public interface IAuctionService
    {
        List<Data.Auction> GetAllAuctions();
        Data.Auction GetAuctionById(int auctionId);

        List<Item> GetItemsByAuction(int auctionId);
        Item GetItemByItemId(int itemId);
        
        List<Bid> GetBidsByItemId(int itemId);
        Bid CommitToBid(Bid bid, int itemId);
    }
}
