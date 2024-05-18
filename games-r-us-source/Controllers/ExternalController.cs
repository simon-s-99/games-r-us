using Microsoft.AspNetCore.Mvc;
using games_r_us_source.Data;
using games_r_us_source.Components.Helpers;
using Microsoft.EntityFrameworkCore;

namespace games_r_us_source.Controllers
{
    // change route name if we add more api's in the future 
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExternalController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns ten listings at a time with their associated owner and highest bid.
        /// </summary>
        [HttpGet("listings")]
        public async Task<ActionResult<IEnumerable<GenericResponseDTO>>> GetListings([FromQuery] int pageNr = 0)
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
                result[i] = new GenericResponseDTO();

                Bid? highestBid = BidHelper.GetHighestBidFromListingID(listings[i].ID, _context);

                // set highestbid to startingprice if listing has no bids 
                if (highestBid is null)
                {
                    result[i].HighestBid = listings[i].StartingPrice;
                }
                else
                {
                    result[i].HighestBid = highestBid.Amount;
                }

                result[i].ListingOwner = ApplicationUserHelper.GetAccountFromUserID(
                    listings[i].ApplicationUserID, _context).FullName;

                result[i].Name = listings[i].Name;

                // if listing has a description take the first 100 chars
                if (listings[i].Description is not null)
                {
                    result[i].ShortDescription = listings[i].Description.Length >= 100 ? 
                        listings[i].Description.Substring(0, 100) : listings[i].Description.Substring(0);
                }
                else // otherwise set to string.Empty 
                {
                    result[i].ShortDescription = "";
                }

                result[i].Platform = listings[i].Platform;
                result[i].GameCategory = listings[i].GameCategory;
            }

            return Ok(result);
        }
    }
}
