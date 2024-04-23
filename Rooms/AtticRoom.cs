using System;
using NarrativeProject.Items;

namespace NarrativeProject.Rooms
{
    internal class AtticRoom : Room
    {
        internal static bool isKeyCollected = false;

        internal override string CreateDescription() =>
@"In the attic, it's dark and cold.
A chest is locked with the code [????].
You can return to your [bedroom].
";

        internal override void ReceiveChoice(string choice)
        {
            if (choice == Game.codeArr[0] && !isKeyCollected)
            {
                Console.WriteLine("The chest opens and you get a key.");
                isKeyCollected = true;
                Game.addItem(new Key());
                return;
            }
            else if (choice == Game.codeArr[0] && isKeyCollected)
            { 
                Console.WriteLine("You already got the key!");
                return;
            }
            
            switch (choice)
            {
                case "bedroom":
                    Console.WriteLine("You return to your bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                /*case "2024":
                    Console.WriteLine("The chest opens and you get a key.");
                    isKeyCollected = true;
                    break;*/
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
