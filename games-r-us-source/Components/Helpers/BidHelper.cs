using games_r_us_source.Data;

namespace games_r_us_source.Components.Helpers
{
    public class BidHelper
    {
        public static Data.Bid GetHighestBidFromListingID(int listingID, ApplicationDbContext context)
        {
            Data.Bid bid = context.Bids.Where(b => b.ID == listingID).OrderByDescending(b => b.Amount).FirstOrDefault();
            return bid;
        }
    }
}
