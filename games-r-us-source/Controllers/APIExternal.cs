using Microsoft.AspNetCore.Mvc;
using games_r_us_source.Data;
using games_r_us_source.Components.Helpers;

namespace games_r_us_source.Controllers
{
    // change route name if we add more api's in the future 
    [Route("api")]
    [ApiController]
    public class APIExternal : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public APIExternal(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns ten listings at a time with their associated owner and highest bid.
        /// </summary>
        [HttpGet("listings")]
        public async Task<ActionResult<Listing[]>> GetListings([FromQuery] int pageNr = 0)
        {
            // if pageNr is not entered (null) it is set to 0 automagically by .net

            // get 10 listings paginated 
            Listing[] listings = _context.Listings
                .OrderBy(l => l.AuctionEnd)
                .Skip(10 * pageNr)
                .Take(10)
                .ToArray();

            GenericResponseDTO[] result = new GenericResponseDTO[listings.Length];

            // get top bid foreach listing & owner of listing
            for (int i = 0; i < listings.Length; i++)
            {
                result[i].HighestBid = BidHelper.GetHighestBidFromListingID(listings[i].ID, _context).Amount;
                result[i].ListingOwner = ApplicationUserHelper.GetAccountFromUserID(
                    listings[i].ApplicationUserID, _context).FullName;

                result[i].Name = listings[i].Name;
                result[i].ShortDescription = listings[i].Description.Substring(0, 100);
                result[i].Platform = listings[i].Platform;
                result[i].GameCategory = listings[i].GameCategory;
            }

            return Ok(result);
        }
    }
}
