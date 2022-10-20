
namespace Shoota
{
    internal class Ship
    {
            public int HP { get; set; }
            public string Name { get; set; }
            public ConsoleColor ShipColor { get; set; }
            public int Points { get; set; }
            public string Description { get; set; }

        public Ship(string name, int hp, ConsoleColor shipColor, int points, string description)
        {
            Name = name;
            HP = hp;
            ShipColor = shipColor;
            Points = points;
            Description = description;
        }


    }

    internal class Player
    {
        public int Points { get; set; }
        public Player()
        {
            Points = 0;
        }
    }

}


