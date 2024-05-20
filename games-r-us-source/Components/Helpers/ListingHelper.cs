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

        public static string GetTimeDifference(DateTime endDate)
        {
            TimeSpan timeDifference = endDate - DateTime.Now;

            if (timeDifference.TotalDays >= 7)
            {
                int weeks = (int)(timeDifference.TotalDays / 7);
                int days = (int)(timeDifference.TotalDays % 7); // Get remaining days after full weeks
                if (days > 0)
                    return $"{weeks} weeks, {days} days";
                else
                    return $"{weeks} weeks";
            }
            else if (timeDifference.TotalDays >= 1)
            {
                int days = (int)timeDifference.TotalDays;
                int hours = timeDifference.Hours;
                if (hours > 0)
                    return $"{days} days, {hours} hours";
                else
                    return $"{days} days";
            }
            else if (timeDifference.TotalHours >= 1)
            {
                int hours = (int)timeDifference.TotalHours;
                int minutes = timeDifference.Minutes;
                if (minutes > 0)
                    return $"{hours} hours, {minutes} min";
                else
                    return $"{hours} hours";
            }
            else if (timeDifference.TotalMinutes >= 1)
            {
                int minutes = (int)timeDifference.TotalMinutes;
                int seconds = timeDifference.Seconds;
                if (seconds > 0)
                    return $"{minutes} min, {seconds} sec";
                else
                    return $"{minutes} min";
            }
            else if (timeDifference.TotalSeconds >= 1)
            {
                return $"{(int)Math.Floor(timeDifference.TotalSeconds)} sec";
            }
            else
            {
                return "";
            }
        }
    }
}
