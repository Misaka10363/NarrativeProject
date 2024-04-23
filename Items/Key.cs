using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Items
{
    internal class Key : Item
    {
        private string itemName = "Key";
        internal bool isWeapon = false;

        internal override void CreateDescription()
        {
            Console.WriteLine("A key to your livingroom. ");
        }
        internal override string getItemName() => itemName;
    }
}
