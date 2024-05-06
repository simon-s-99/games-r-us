using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace games_r_us_source.Data
{
    public enum Platform
    {
        XBOX,
        PlayStation,
        GameCube,
        NintendoSwitch,
        NintendoWii,
        NintendoDS,
        Nintendo64,
        GameBoy
    }

    public enum GameCategory
    {
        FPS,
        Sports,
        Fantasy,
        RPG,
        Sandbox,
        Platformer,
        MMO,
        TurnBased,
        FourX,
        Strategy,
        Simulator,
        Action,
        Horror,
        Fighting,
        Indie,
        Survival
    }

    public class Listing
    {
        public int ID { get; set; }

        [ForeignKey("ApplicationUserID")]
		public string ApplicationUserID { get; set; }

		[NotMapped]
        [DeleteBehavior(DeleteBehavior.NoAction)] // sets AccountID to null if the related account is deleted 
		public ApplicationUser ApplicationUser { get; set; }

        [StringLength(maximumLength:50, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 50 characters")]
        public string Name { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Starting price must be at least 1")]
        public decimal StartingPrice { get; set; }

        public string? ImagePath { get; set; }

		[MaxLength(1024, ErrorMessage = "Description cannot exceed 1024 characters")]
		public string? Description { get; set; }

        public DateTime AuctionEnd { get; set; }

        public Platform Platform { get; set; }

        public GameCategory? GameCategory { get; set; }
    }
}
