using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Items
{
    internal class HealthPotion : Item
    {
        private string itemName = "Health Potion";
        private bool ifEmpty = false;
        internal bool isWeapon = false;
        internal override void CreateDescription()
        {
            Console.WriteLine("A potion that recover 50 of your health point.");
            Console.WriteLine("Enter y to use it, or anykey to return: ");
            string str = Console.ReadLine().ToLower() ?? "";
            if (str == "y") usePotion();
            else return;
        }
        internal override string getItemName() => itemName;
        private void usePotion()
        {
            if (!ifEmpty)
            { 
                Game.addHealth(50);
                ifEmpty = true;
                itemName = "Health Potion (empty)";
            }
            else if (ifEmpty)
            {
                Console.WriteLine("It is empty!");
                Console.ReadLine();
            }
        }
    }
}
