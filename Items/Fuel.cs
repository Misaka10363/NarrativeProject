using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Items
{
    internal class Fuel : Item
    {
        private string itemlName = "Fuel";
        internal static bool isCollected;

        internal override void CreateDescription()
        {
            Console.WriteLine(
@"Some fuel. You can use it in the car in your garage.") ;
        }
        
        internal override string getItemName() => itemlName;
    }
}
