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
        void CreateAuction(Data.Auction auction);

        List<Item> GetItemsByAuction(int auctionId);
        Item GetItemByItemId(int itemId);
        void CreateAuctionItem(Item item);
        
        List<Bid> GetBidsByItemId(int itemId);
        Bid CommitToBid(int auctionId, int itemId, Bid bid);
    }
}
