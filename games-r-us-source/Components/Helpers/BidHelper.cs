using games_r_us_source.Data;

namespace games_r_us_source.Components.Helpers
{
    public class BidHelper
    {
        public static Data.Bid? GetHighestBidFromListingID(int listingID, ApplicationDbContext context)
        {
            Data.Bid? highestBid = context.Bids
           .Where(b => b.ListingID == listingID)
           .OrderByDescending(b => b.Amount)
           .FirstOrDefault();

            return highestBid;
        }
    }
}
