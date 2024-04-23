using NarrativeProject.Items;
using System;
using System.Runtime.Remoting.Messaging;

namespace NarrativeProject.Rooms
{
    internal class Bedroom : Room
    {
        bool isSafeLooted;
        internal override string CreateDescription() =>
@"You are in your bedroom.
The [door] in front of you leads to your living room.
Your private [bathroom] is to your left.
From your closet, you see the [attic].
There is a safe beside your bed locked with code [????].
";

        internal override void ReceiveChoice(string choice)
        {
            if (choice == Game.codeArr[1] && !isSafeLooted)
            {
                Console.WriteLine("You find a Glock 26 inside the safe.");
                Game.addItem(new Glock26());
                if (Game.dropChance() >= 5)
                {
                    Console.WriteLine("You find a Health Potion inside the safe."); 
                    Game.addItem(new HealthPotion());
                }
                isSafeLooted = true;
                return;
            }

            else if (choice == Game.codeArr[1] && isSafeLooted) 
            { 
                Console.WriteLine("Safe is empty!");
                return;
            }

                switch (choice)
            {
                case "bathroom":
                    Console.WriteLine("You enter the bathroom.");
                    Game.Transition<Bathroom>();
                    break;
                case "door":
                    if (!AtticRoom.isKeyCollected)
                    {
                        Console.WriteLine("The door is locked.");
                    }
                    else
                    {
                        Console.WriteLine("You open the door with the key and leave your bedroom.");
                        Console.WriteLine("You enter livingroom.");
                        Game.Transition<Livingroom>();
                        //Game.Finish();
                    }
                    break;
                case "attic":
                    Console.WriteLine("You go up and enter your attic.");
                    Game.Transition<AtticRoom>();
                    break;
                /*case "1":
                    Console.WriteLine("Basement.");
                    Game.Transition<Basement>();*/
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
