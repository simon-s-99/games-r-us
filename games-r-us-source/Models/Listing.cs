using System.ComponentModel.DataAnnotations.Schema;
using games_r_us_source.Classes;
using Microsoft.EntityFrameworkCore;

namespace games_r_us_source.Models
{
    public class Listing
    {
        public int ID { get; set; }

        [ForeignKey("AccountID")]
        public int AccountID { get; set; }

        // sets AccountID to null if the related account is deleted
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Account Account { get; set; }

        public string Name { get; set; }

        public decimal StartingPrice { get; set; }

        public string? ImagePath { get; set; }

        public string? Description { get; set; }

        public DateTime AuctionEnd { get; set; }

        public CompositeCategory Categories { get; set; }
    }
}
