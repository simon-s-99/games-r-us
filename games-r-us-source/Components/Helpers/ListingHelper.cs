using games_r_us_source.Data;

namespace games_r_us_source.Components.Helpers
{
    public class ListingHelper
    {
        public static Data.Listing GetListingFromListingID(int listingID, ApplicationDbContext context)
        {
            Data.Listing listing = context.Listings.Where(l => l.ID == listingID).FirstOrDefault();
            return listing;
        }
    }
}
