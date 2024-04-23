using NarrativeProject.Rooms;
using System;
using System.CodeDom.Compiler;

namespace NarrativeProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Add(new Bedroom());
            game.Add(new Bathroom());
            game.Add(new AtticRoom());
            game.Add(new Livingroom());
            game.Add(new Basement());
            game.Add(new Garage());

            game.codeGenerator();

            while (!game.IsGameOver())
            {

                Console.WriteLine("[bag] [stats]");
                Console.WriteLine("--");
                Console.WriteLine(game.CurrentRoomDescription);
                string choice = Console.ReadLine().ToLower() ?? "";
                Console.Clear();
                if (choice == "bag")
                {

                    Console.WriteLine(game.checkInventory());
                    int i;
                    int.TryParse(Console.ReadLine(), out i);
                    if (i > 0 || i < 11)
                    {
                        Console.Clear();
                        game.checkItemDetail(i);
                        Console.WriteLine("Hit enter to continue:");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else if (choice == "stats")
                {
                    Console.WriteLine("HP: " + game.checkPlayerHealth()); 
                    Console.WriteLine("Sanity: " + game.checkPlayerSan());
                }
                else game.ReceiveChoice(choice);
            }

            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
