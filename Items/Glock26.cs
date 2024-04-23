using System;

namespace NarrativeProject.Items
{
    internal class Glock26 : Item
    {
        private string itemName = "Glock26";
        internal int damage = 100;
        private int ammoCount = 11;
        internal bool isWeapon = true;

        internal override string getItemName() => itemName;

        internal override void CreateDescription()
        { 
            Console.WriteLine(@"The Glock 26 is a 9×19mm ""subcompact"" variant designed 
for concealed carry and was introduced in 1995, mainly for 
the civilian market.

Damage: 100
Ammo: 10 + 1
Ammo left: " + ammoCount.ToString()); 
        }

        internal int doDamage()
        {
            if (ammoCount <= 0) return 0;
            ammoCount--;
            return damage;
        }

    }
}
