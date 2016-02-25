using System.Collections.Generic;
using System.Web.Http;
using Auction.Backend;
using Auction.Data;
using Auction.Models;
using Microsoft.AspNet.Identity;

namespace Auction.Controllers
{
    public class AuctionController : ApiController
    {
        public AuctionController(IAuctionService auctionService)
        {
            this._auctionService = auctionService;
        }

        public AuctionController() { }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        private readonly IAuctionService _auctionService;

        // GET: api/Auction
        public IEnumerable<Data.Auction> Get()
        {
            var auctions = _auctionService.GetAllAuctions();
            return auctions;
        }

        // GET: api/Auction/5
        public Data.Auction Get(int id)
        {
            var auction = _auctionService.GetAuctionById(id);
            return auction;
        }

        // POST: api/Auction
        public void Post([FromBody]Data.Auction auction)
        {
            _auctionService.CreateAuction(auction);
        }

        [Route("api/Auction/{auctionId}/Items")]
        [HttpGet]
        public IEnumerable<Item> GetauctionItemsByAuctionId(int auctionId)
        {
            var auction = _auctionService.GetAuctionById(auctionId);
            return auction.Items;
        }

        [Route("api/Auction/{auctionId}/Items/{itemId}")]
        [HttpPost]
        public Bid SubmitBid(int auctionId, int itemId, [FromBody]Bid bid)
        {
            return _auctionService.CommitToBid(auctionId, itemId, bid);
        }
   
        // PUT: api/Auction/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Auction/5
        public void Delete(int id)
        {
        }
    }
}
