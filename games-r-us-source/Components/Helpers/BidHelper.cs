using games_r_us_source.Data;

namespace games_r_us_source.Components.Helpers
{
    public class BidHelper
    {
        public static decimal GetHighestBidAmountFromListingID(int listingID, ApplicationDbContext context)
        {
            decimal bid = context.Bids.Where(b => b.ID == listingID).Max(b => b.Amount);
            return bid;
        }
    }
}
