using System;

namespace NarrativeProject.Rooms
{
    internal class Bathroom : Room
    {
        private bool isBathUsed = false;

        internal override string CreateDescription() =>
@"In your bathroom, the [bath] is filled with hot water.
The [mirror] in front of you reflects your depressed face.
You can return to your [bedroom].
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "bath":
                    isBathUsed = true;
                    Console.WriteLine("You relax in the bath.");
                    break;
                case "mirror":
                    if (isBathUsed)
                    {
                        Console.WriteLine("You see the numbers {0} written on the fog on your mirror.", Game.codeArr[0]);
                    }
                    else
                    {
                        Console.WriteLine("You cannot see anything of interest in the mirror.");
                    }
                    break;
                case "bedroom":
                    Console.WriteLine("You return to your bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
