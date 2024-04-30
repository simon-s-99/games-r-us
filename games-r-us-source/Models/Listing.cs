﻿using System.ComponentModel.DataAnnotations.Schema;

namespace games_r_us_source.Models
{
    public enum Category
    {
        Console,
        Game,
        Accessory
    }

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

        [ForeignKey("AccountID")]
        public int AccountID { get; set; }

        public Account Account { get; set; }

        public string Name { get; set; }

        public decimal StartingPrice { get; set; }

        public string? ImagePath { get; set; }

        public string? Description { get; set; }

        public DateTime AuctionEnd { get; set; }

        public (Category, Platform, GameCategory?) Categories { get; set; }
    }
}