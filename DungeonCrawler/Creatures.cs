using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DungeonCrawler.GameItems;
using static DungeonCrawler.Rooms;

namespace DungeonCrawler
{
    internal class Creatures
    {
        public abstract class Creature
        {
            //parent class in advance for part 2 of assignment
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int MAXHP { get; set; }
            public int HP { get; set; }
            public Room CurrentRoom { get; set; }

            

            public Creature(Room StartingRoom)
            {
                Name = "Creature";
                Description = "This shouldn't exist.";
                CurrentRoom = StartingRoom;

            }

        }
        public class Player : Creature
        {
            public List<GameItem> Inventory = new();
            public Player(Room StartingRoom) : base(StartingRoom)

            {
                Name = "Player";
                Description = "This is you.";
                MAXHP = 10;
                HP = 10;
                CurrentRoom = StartingRoom;
                

        }

            public void Look()
            {
                Console.WriteLine("This room is " + CurrentRoom.Name);
                Console.WriteLine(CurrentRoom.Description);

                if (CurrentRoom.Inventory.Count == 0)
                {
                    Console.WriteLine("There's nothing here");

                }
                else
                {
                    Console.WriteLine("This room contains:");
                 
                    foreach (GameItem item in CurrentRoom.Inventory)
                    {
                        Console.Write(CurrentRoom.Inventory.IndexOf(item) + 1 + ". ");
                        Console.WriteLine(item.Name);
                    }
                }
            }

            public void CheckInventory()
            {
                if (Inventory.Count == 0)
                {
                    Console.WriteLine("Your bag is empty");
                    return;

                }
                else
                {
                    Console.WriteLine("There are items in your bag:");

                    foreach (GameItem item in Inventory)
                    {
                        Console.Write(Inventory.IndexOf(item) + 1 + ". ");
                        Console.WriteLine(item.Name);
                    }
                }
            }
            public void PickUpItem()
            {
                //example of guard clause
                //exits early to prevent null error

                if (CurrentRoom.Inventory.Count == 0)
                {
                    Console.WriteLine("There's nothing to pick up here...");
                    return;

                }
                else 
                {
                    Console.WriteLine("There are items here:");

                    foreach (GameItem item in CurrentRoom.Inventory)
                    {
                        Console.Write(CurrentRoom.Inventory.IndexOf(item) + 1 + ". ");
                        Console.WriteLine(item.Name);
                    }

                    Console.WriteLine("Which item do you wish to procure?");
                    string input = Console.ReadLine().ToLower();

                    if (!CurrentRoom.Inventory.Any(GameItem => GameItem.Name.Contains(input)))
                    {
                        Console.WriteLine("Item not found, perhaps you mistyped?");

                    }
                    else
                    {
                        this.Inventory.Add(CurrentRoom.Inventory.Find(GameItem =>GameItem.Name.Contains(input)));
                        CurrentRoom.Inventory.Remove(CurrentRoom.Inventory.Find(GameItem => GameItem.Name.Contains(input)));
                    }


                


                


                }
            }


        }



    }
}
