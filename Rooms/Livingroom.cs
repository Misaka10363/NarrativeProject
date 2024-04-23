using System;
using NarrativeProject.Items;

namespace NarrativeProject.Rooms
{
    internal class Livingroom : Room
    {
        internal override string CreateDescription() =>
@"In your living room, [garage] is on your left, [stairs] 
to basement is on your right. You can use the door behind 
you to go back to [bedroom]. There is a [photo frame]on 
the wall.
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "photo frame":
                    Console.WriteLine(
@"You pick up the photo frame.There is an old picture
with your family. You find a note with a number behind it:
{0}", Game.codeArr[1]);
                    Console.WriteLine();
                    break;

                case "bedroom":
                    Console.WriteLine("You return to your bedroom.");
                    Game.Transition<Bedroom>();
                    break;

                case "stairs":
                    Console.WriteLine("You enter basement.");
                    Game.Transition<Basement>();
                    break;

                case "garage":
                    Console.WriteLine("You enter basement.");
                    Game.Transition<Garage>();
                    break;

                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
