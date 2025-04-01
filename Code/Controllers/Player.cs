using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace DungeonExplorer
{

    public class Player : Creature
    {

        private List<GameItems> Inventory = new List<GameItems>();

        public Torch EquippedTorch { get; set; }
        public Sword EquippedSword { get; set; }

        private Dictionary<string, int> Cardinality { get; set; }

        public  Player()
        {

            MAXHP = 100;
            HP = MAXHP;
            DefaultTorch torch = new();
            Description = "You've seen better days.";
            EquippedTorch = torch;

        }
        public Player(Room location) : base(location)
            {
                currentRoom = location;

                MAXHP = 100;
                HP = MAXHP;
                 DefaultTorch torch = new();

                 EquippedTorch = torch;


            Cardinality = new();
            this.Cardinality.Add("North", 0);
            this.Cardinality.Add("East", 1);
            this.Cardinality.Add("South", 2);
            this.Cardinality.Add("West", 3);

            Debug.Assert(Name != null);
                Debug.Assert(HP != 0 && MAXHP != 0);
                Debug.Assert(currentRoom != null);
        }
        
         ///<Summary>
         ///Displays Room name, Description and items.
         ///</Summary>

            public void Look()
            {
                //display room fluff

                Console.WriteLine("This room is " + currentRoom.Name + "\n");
                Console.WriteLine(currentRoom.GetDescription());

                //check if room has items

                currentRoom.GetContents();

            }
         /// <summary>
         /// Displays items in inventory.
         /// </summary>
            public void GetInventory()
            {
                if (Inventory.Count == 0)
                {
                    Console.WriteLine("Your bag is empty");
                    return;

                }
                else
                {
                    Console.WriteLine("There are items in your bag:");

                    foreach (GameItems item in Inventory)
                    {
                        Console.Write(Inventory.IndexOf(item) + 1 + ". ");
                        Console.WriteLine(item.Name);
                    }
                }
            }
         /// <summary>
         /// Transfers item from room to player.
         /// </summary>
            public void PickUpItem()
            {
                //example of guard clause
                //exits early to prevent null error

                if (currentRoom.Inventory.Count == 0)
                {
                    Console.WriteLine("There's nothing to pick up here...");
                    return;

                }
                else
                {
                    Console.WriteLine("There are items here:");

                    foreach (GameItems item in currentRoom.Inventory)
                    {
                        Console.Write(currentRoom.Inventory.IndexOf(item) + 1 + ". ");
                        Console.WriteLine(item.Name);
                    }

                    Console.WriteLine("Which item do you wish to procure?");
                    string input = Console.ReadLine().ToLower();

                    if (!currentRoom.Inventory.Any(GameItems => GameItems.Name.ToLower().Contains(input)))
                    {
                        Console.WriteLine("Item not found, perhaps you mistyped?");

                    }
                    else
                    {
                        var target = currentRoom.Inventory.Find(GameItems => GameItems.Name.ToLower().Contains(input));
                        this.Inventory.Add(target);
                        currentRoom.Inventory.Remove(target);

                        Console.WriteLine("Picked up the {0}", target.Name);
                    }

                }
            }

        /// <summary>
        /// Moves to next room in Map
        /// </summary>
        /// <param name="Map"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Move_Forward(List<Room> Map)
        {
            int Index = currentRoom.GetID();

            try
            { currentRoom = Map[Index + 1];
                Console.WriteLine("You move forward..."); }

            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("There doesn't seem to be anything that way.");
                return;
            }

        }
        /// <summary>
        /// Moves to previous room in Map
        /// </summary>
        /// <param name="Map"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Move(int direction)
        {
            try
            {
                currentRoom = currentRoom.Connections[direction];
                Console.WriteLine("You move forward...");
            }

            catch (KeyNotFoundException)
            {
                Console.WriteLine("There doesn't seem to be anything that way.");
                return;
            }

        }
        }
    }
