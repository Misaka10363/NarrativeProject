using NarrativeProject.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Garage : Room
    {
        internal override string CreateDescription() =>
@"You find a [car] with a [note] on the window.
Use [door] to go back to livingroom.";
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "note":
                    Console.WriteLine("RUN!!!  @(*#&%(*)(E&)&(*@$&)&)(@HUIH*)DF....");
                    Console.WriteLine("Rest of the note is unreadable....");
                    break;

                case "car":
                    Console.WriteLine("You enter the car. Try start the engine [y]");
                    string str = Console.ReadLine().ToLower();
                    if (str == "y")
                    {
                        Console.WriteLine("It seems the car ran out of fuel.");
                        if (Fuel.isCollected)
                        {
                            Console.WriteLine("Do you want to add fuel? [y]");
                            str = Console.ReadLine().ToLower();
                            if (str == "y")
                            {
                                Console.WriteLine("You escape the house!");
                                Game.Finish();
                            }
                        }
                    }
                    break;
                case "door":
                    Console.WriteLine("You enter livingroom.");
                    Game.Transition<Livingroom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
        
    }
}
