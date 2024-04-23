using NarrativeProject.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Basement : Room
    {
        Random rd = new Random();
        bool isPaintChecked;
        internal override string CreateDescription()
        {
             return
@"You are in your basement.
You saw a [paint] on the wall with some runes nearby.
It seems someone host a ritual in your basement.
In the cornor there is a large [toolbox].
You can use [stairs] to go back livingroom.
";
        }

        

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "paint":
                    int sancheck = 0;
                    Console.WriteLine("You saw a paint of someone with green octopus tentacles. Seems like he is looking at you as well.");
                    if (isPaintChecked) break;

                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine("Would you like to look closer? [y]");
                        string str = Console.ReadLine();

                        if (str.ToLower() == "y")
                        {
                            Console.WriteLine("You heard someone calling you from far away...");
                            Game.reduceSan(rd.Next(6,10));
                            //Console.WriteLine(Game.checkSan());
                            isPaintChecked = true;
                            sancheck++;

                            if (Game.isFinished) break;
                        }

                    }

                    if (sancheck == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("You heard something about Cthulhu.");
                    }
                    break;

                case "toolbox":
                    Console.WriteLine("You find some fuel! You can probably use that in your garage.");
                    Game.addItem(new Fuel());
                    Fuel.isCollected = true;
                    break;

                case "stairs":
                    Console.WriteLine("You go back to your living room.");
                    Game.Transition<Livingroom>();
                    break;

                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
