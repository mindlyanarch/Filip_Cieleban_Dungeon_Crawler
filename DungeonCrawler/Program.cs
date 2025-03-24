
using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using static DungeonCrawler.GameItems;
using static DungeonCrawler.Rooms;
using static DungeonCrawler.Creatures;


namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {


            //List<Room> Rooms = new List<Room>();
            //{
            //    
            //}

           

            Sword Rusty_Sword = new Sword();
            EntranceRoom StartingRoom = new();
            StartingRoom.Inventory.Add(Rusty_Sword);
            Player Player = new(StartingRoom);

            
            

            //Room Findroom = Rooms.FirstOrDefault(p => p.Id == Player.CurrentRoom);




            while (true)
            {
                
                Console.WriteLine("Type 'look' to check where you are, or 'exit' to quit.");
                Console.WriteLine("Type 'Inventory' to check your bag, or 'Pickup' to grab an item");
                string? input = Console.ReadLine()?.ToLower();

                if (input == "look")
                {
                    Player.Look();
                }
                else if (input == "pickup")
                {
                    Player.PickUpItem();
                }
                else if(input == "inventory")
                {
                    Player.CheckInventory();
                }
                else if (input == "exit")
                {
                    break;
                }

            }
        }
    }
}
