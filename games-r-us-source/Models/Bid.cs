using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace games_r_us_source.Models
{
    public class Bid
    {
        public int ID {  get; set; }

        [ForeignKey("ListingID")]
        public int ListingID { get; set; }

        // sets ListingID to null if the related listing is deleted
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Listing Listing { get; set; }

        // account that placed the bid 
        [ForeignKey("AccountID")]
        public int AccountID {  get; set; }

        // sets AccountID to null if the related account is deleted
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Account Account { get; set; }

        public decimal Amount { get; set; }

        // time bid was placed
        public DateTime Time { get; set; }
    }
}
