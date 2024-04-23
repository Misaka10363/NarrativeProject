using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject
{
    internal class Player
    {
        private int health = 100;
        private int sanity = 20;
        //string[] inventory = new string[10];
        private int inventoryIndex = 0;
        List<Item> items = new List<Item>();

        internal string addItem(Item item)
        {
            if (inventoryIndex > 10) return "Your inventory is full!";
            items.Add(item);
            inventoryIndex++;
            return "You pick up " + item.getItemName();
        }

        internal string checkInventory()
        {
            int i = 1;
            string inventoryStutas = "Inventory Slot: " + (inventoryIndex).ToString() + "/10\n";

            foreach (var item in items)
            { 
                inventoryStutas += i.ToString() + ". " + item.getItemName() + "\n";
                i++;
            }
            

            return inventoryStutas;
        }

        internal void chekcItem(int i)
        {
            if (i > inventoryIndex) Console.WriteLine( "Error! Please enter a valid number!");
            else if (i == 0) Console.WriteLine("");
            else if (i > 0 || i < inventoryIndex) items[i - 1].CreateDescription();
            else Console.WriteLine("Error");
        }

        internal string checkHealth() => health.ToString();

        internal  void addHealth(int i)
        {
            health += i;
        }

        internal void recieveDamage(int i)
        {
            health -= i;
        }

        internal int checkSan() => sanity;
        internal void lostSan(int i) { sanity -= i; }
        
    }
}
