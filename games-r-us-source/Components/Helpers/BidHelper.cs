using games_r_us_source.Data;

namespace games_r_us_source.Components.Helpers
{
    public class BidHelper
    {
        public static Data.Bid? GetHighestBidFromListingID(int listingID, ApplicationDbContext context)
        {
            var listingBids = context.Bids.Where(b => b.ListingID == listingID);
            Data.Bid highestBid = null;

            // If bids for the current listing exist
            if (listingBids.Any())
            {
                highestBid = listingBids.OrderByDescending(b => b.Amount).FirstOrDefault();
            }

            return highestBid;
        }
    }
}
