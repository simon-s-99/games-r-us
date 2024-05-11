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
        [NotMapped]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Listing Listing { get; set; }

        [ForeignKey("ApplicationUserID")]
        public string ApplicationUserID { get; set; } // account that placed the bid 

        [NotMapped]
        [DeleteBehavior(DeleteBehavior.NoAction)] // sets AccountID to null if the related account is deleted 
        public ApplicationUser ApplicationUser { get; set; }

        public decimal Amount { get; set; }

        // time bid was placed
        public DateTime Time { get; set; }

        [NotMapped]
        public BidStatus Status { get; set; }
    }
    public enum BidStatus
    {
        Won,
        Lost,
        Leading,
        Losing
    }
}
