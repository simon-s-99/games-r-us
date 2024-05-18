namespace games_r_us_source.Data
{
    // meant to be used in APIExternal as a generic DTO
    // for 10 listings + highestBid + listing owner 
    public class GenericResponseDTO
    {
        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Platform { get; set; }

        public string? GameCategory { get; set; }

        public decimal HighestBid { get; set; }

        public string ListingOwner { get; set; }
    }
}
