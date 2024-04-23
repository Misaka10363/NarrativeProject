using NarrativeProject.Items;
using NarrativeProject.Rooms;
using System;
using System.Collections.Generic;

namespace NarrativeProject
{
    internal class Game
    {
        List<Room> rooms = new List<Room>();
        Room currentRoom;

        List<Item> items = new List<Item>();
        static Player player1 = new Player();

        static Random rd = new Random();
        internal static string[] codeArr = new string[2]; //0 for attic, 1 for bedroom
        internal void codeGenerator()
        {
            codeArr[0] = rd.Next(0, 10).ToString()+ rd.Next(0, 10).ToString()+ rd.Next(0, 10).ToString()+ rd.Next(0, 10).ToString();
            codeArr[1] = rd.Next(0, 10).ToString() + rd.Next(0, 10).ToString() + rd.Next(0, 10).ToString() + rd.Next(0, 10).ToString();
            Console.WriteLine(codeArr[0] + " " + codeArr[1]);
        }
        internal static int dropChance() => rd.Next(0, 10);

        internal bool IsGameOver() => isFinished;
        internal static bool isFinished = false;
        static string nextRoom = "";

        internal void Add(Room room)
        {
            rooms.Add(room);
            if (currentRoom == null)
            {
                currentRoom = room;
            }
        }

        internal string CurrentRoomDescription => currentRoom.CreateDescription();

        internal void ReceiveChoice(string choice)
        {
            currentRoom.ReceiveChoice(choice);
            CheckTransition();
        }

        internal static void Transition<T>() where T : Room
        {
            nextRoom = typeof(T).Name;
        }

        internal static void Finish()
        {
            isFinished = true;
        }

        internal void CheckTransition()
        {
            foreach (var room in rooms)
            {
                if (room.GetType().Name == nextRoom)
                {
                    nextRoom = "";
                    currentRoom = room;
                    break;
                }
            }
        }

        internal string checkPlayerHealth() => player1.checkHealth();
        internal string checkInventory() => player1.checkInventory();
        internal string addInventory(Item itemName) => player1.addItem(itemName);
        internal void checkItemDetail(int i)
        {
            player1.chekcItem(i);
        }
        internal static void addItem(Item item)
        {
            Console.WriteLine(player1.addItem(item));
            Console.ReadLine();
        }

        internal static void addHealth(int i)
        {
            player1.addHealth(i);
            Console.WriteLine("You heal {0} HP!", i.ToString());
        }

        internal static void recieveDamage(int i)
        {
            player1.recieveDamage(i);
            Console.WriteLine("You recieve {0} damage!", i.ToString());
            Console.WriteLine("You have {0} health left.", player1.checkHealth().ToString());
            if (int.Parse(player1.checkHealth()) <= 0) Finish();
        }

        internal static int checkSan() => player1.checkSan();

        internal static void reduceSan(int i)
        {
            player1.lostSan(i);
            if (player1.checkSan() <= 0)
            {
                Console.WriteLine("You lost your mind!");
                Finish();
            }
        }


    }
}
