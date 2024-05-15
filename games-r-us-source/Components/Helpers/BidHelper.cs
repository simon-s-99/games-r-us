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

        public static string GetTimeDifference(DateTime endDate)
        {
            if (DateTime.Now > endDate)
            {
                return "ended";
            }

            TimeSpan timeDifference = endDate - DateTime.Today;

            if (timeDifference.TotalDays >= 7)
            {
                // Round down
                double wholeWeeks = Math.Floor(timeDifference.TotalDays / 7);

                // Get the rest value
                double wholeDays = Math.Round(timeDifference.TotalDays % 7);

                return wholeWeeks + " weeks" + (wholeDays > 0 ? $", {wholeDays} days" : "");
            }

            return timeDifference.TotalDays + " days";
        }
    }

}
