


namespace Shoota
{
    internal class Program
    {
        public static Player? Player { get; set; } // ? means it can be nullable. Safety precaution

        public static List<Ship> Ships { get; set; }        // making ships list to be used later.
        static void Main(string[] args)
        {
            Program program = new Program();
            Player = new Player();
            Ships = CreateShip();

            /*
            Ship ship1 = new Ship("Space trash", 2); // name, hp
            Ship ship2 = new Ship("Death Star", 10);
            Ship ship3 = new Ship("Medium Sized Ship", 5);
            */

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Beep boop. k-zkzkzzkkrrtt. You are an automated evil turret and your automatic targeting chip has been damaged in an orbital bombardment. ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("What do? (only use 1-0, isnullorwhitespace not yet implemented");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1) Scan the Sky. 2) quit");
            Console.ResetColor();
            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine();
            // to do

            while (true)
            {

                if (choice == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("You scan the sky.");
                    Console.ResetColor();

                    var ship = program.SkyScan();                       // calling method skyscan
                    if (ship == null)
                    {
                        EndGame();
                    }
                    Console.ForegroundColor = ship.ShipColor;
                    Console.WriteLine("You spot a {0}, {2}, It has {1} Hull integrity", ship.Name, ship.HP, ship.Description);
                    Console.WriteLine("");


                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("What do you want to do?");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine("1) Shoot 2) Flee");

                    Console.ResetColor();
                    int choice2 = int.Parse(Console.ReadLine());
                    if (choice2 == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You shoot at {0}", ship.Name);
                        Console.WriteLine();

                        ReduceHP(ship);
                        if (ship.HP <= 0)
                        {
                            ExplodeShip(ship);
                        }

                        Console.ResetColor();
                    }
                    else if (choice2 == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You flee. What a pussy");
                        Console.ResetColor();
                        Console.Beep();
                        break;
                    }

                }


                else if (choice == 2)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("No one likes quitters");
                    Console.ResetColor();
                    break;
                }
            }
        }

        public Ship SkyScan()
        {
            //Ship ship = new Ship();
            Random rnd = new Random();
            int rndNr = rnd.Next(1, Ships.Count + 1);
            if (Ships != null && Ships.Count > 0)
            {
                var ship = Ships[rndNr - 1];
                return ship;
            }
            return null;


            // MUISTOJA PASKASTA KOODISTA
            //if (rndNr == 1)
            //{
            //    Console.ForegroundColor = ConsoleColor.Yellow;
            //    Console.WriteLine("All you see is {0} not really worth shooting. It has {1} HP", ships[0].Name, ships[0].HP);
            //    Console.ResetColor();

            //}
            //else if (rndNr == 2)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("You spot an {0}. It approaches you. It has {1} HP", ships[1].Name, ships[1].HP);
            //    Console.ResetColor();
            //}
            //else if (rndNr == 3)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("You see an {0} full of civilians, it has {1} HP", ships[2].Name, ships[2].HP);
            //    Console.ResetColor();
            //}

        }

        public static void ReduceHP(Ship ship)
        {
            ship.HP = ship.HP - 1;


        }

        public static void ExplodeShip(Ship ship)
        {

            Player.Points = Player.Points + ship.Points;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("you got {0} points", Player.Points);
            Console.ResetColor();
            Ships.Remove(ship);

            if (Ships.Count == 0)
            {
                Winrar();
            }


            // alert current points, 
        }

        public static void Winrar()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You is winrar!");
            Console.ResetColor();
            
            Console.WriteLine("Skies are clear");
        }

        public static void EndGame()
        {
            Console.Beep();
            Console.ReadLine();
            Environment.Exit(0);
        }

        public static List<Ship> CreateShip()
        {
            Random rnd = new Random();
            int rndNr = 3;
            var ships = new List<Ship>()
            { new Ship("Useless Debris", 2, ConsoleColor.DarkYellow, 1,"full of all kinds of junk"),
            new Ship("Death Star", 10, ConsoleColor.Red, 10, "attached to it are banners that indicate it's 'bring your children to work day'"),
            new Ship("Medium Sized Ship", 5, ConsoleColor.DarkYellow, 1, "full of civilians"),
            new Ship("Tie-Fighter", 5, ConsoleColor.Green, 5, "with Groku inside"),
            new Ship("Ewok Cruiser", 3, ConsoleColor.DarkYellow, 2,"the ewoks are sooooo cute"),
            new Ship("USS Enterprise", 8, ConsoleColor.Red, 8, "on captain Kirk's birthday"),
            new Ship("Tardis", 4, ConsoleColor.Blue, 4, "which is bigger from inside"),
            new Ship("The Magic Bus", 6, ConsoleColor.Green, 6, "full of children"),
            new Ship("American Satellite", 3, ConsoleColor.DarkYellow, 3, "declaring world peace"),
            new Ship("Mary Poppins", 8, ConsoleColor.DarkYellow, 2, "flying with umbrella")};

            var randomShips = new List<Ship>();

            for (int i = 0; i < rndNr; i++)
            {
                int max = ships.Count - 1;
                int rndNr2 = rnd.Next(0,max);
                randomShips.Add(ships[rndNr2]);
                ships.Remove(ships[rndNr2]);
            }


            return randomShips;

        }



    }
}
