using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace games_r_us_source.Data
{
    public class Bid
    {
        public int ID { get; set; }

        [ForeignKey("ListingID")]
        public int ListingID { get; set; }

        // sets ListingID to null if the related listing is deleted
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Listing Listing { get; set; }

        // account that placed the bid 
        [ForeignKey("ApplicationUserID")]
        public int ApplicationUserID { get; set; }

        // sets AccountID to null if the related account is deleted
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public ApplicationUser ApplicationUser { get; set; }

        public decimal Amount { get; set; }

        // time bid was placed
        public DateTime Time { get; set; }
    }
}
