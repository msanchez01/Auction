using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Auction.Backend;
using Auction.Models;
using Microsoft.AspNet.Identity;

namespace Auction.Controllers
{
    public class AuctionController : ApiController
    {
        public AuctionController(IAuctionService auctionService)
        {
            this.AuctionService = auctionService;
        }

        public AuctionController() { }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        private IAuctionService AuctionService;

        // GET: api/Auction
        public IEnumerable<Data.Auction> Get()
        {
            var auctions = AuctionService.GetAllAuctions();
            return auctions;
        }

        // GET: api/Auction/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Auction
        public void Post([FromBody]string value)
        {
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
