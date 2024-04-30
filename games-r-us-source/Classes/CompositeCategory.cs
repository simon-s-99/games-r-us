using System.ComponentModel.DataAnnotations.Schema;

namespace games_r_us_source.Classes
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

    [NotMapped]
    public class CompositeCategory
    {
        public Category Category { get; set; }

        public Platform Platform { get; set; }

        public GameCategory? GameCategory { get; set; }
    }
}
