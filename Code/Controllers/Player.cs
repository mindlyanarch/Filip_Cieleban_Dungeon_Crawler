using DungeonExplorer.Code.Items.Potions;
using DungeonExplorer.Code.Items.Swords;
using DungeonExplorer.Code.Items.Torches;
using DungeonExplorer.Code.Map.Rooms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace DungeonExplorer
{

    public class Player : Creature
    {

        //Player Slots

        private List<GameItems> Inventory = new List<GameItems>();
        public Torch EquippedTorch { get; protected set; }
        public Sword EquippedSword { get; protected set; }


        //Tools
        private Dictionary<string, int> Cardinality { get; set; }


        //Items
        private Potion potion;

        public Player()
        {

            //Player stats

                MAXHP = 100;
                HP = MAXHP;
                Description = "You've seen better days.";


            //Starting items

                DefaultTorch torch = new();
                Sword sword = new("Rusty Sword", "It too, has seen better days.", 5);

                potion = new();
                potion = new();
                potion = new();

            EquippedTorch = torch;
            EquippedSword = sword;
            Inventory.Add(potion);

        }

        public Player(Room location) 
        {
            currentRoom = location;

            //Player stats

            MAXHP = 100;
            HP = MAXHP;
            Description = "You've seen better days.";


            //Starting items

            DefaultTorch torch = new();
            Sword sword = new("Rusty Sword", "It too, has seen better days.", 5);

            potion = new();
            potion = new();
            potion = new();

            EquippedTorch = torch;
            EquippedSword = sword;
            Inventory.Add(potion);

            //Tools

            Cardinality = new();
            this.Cardinality.Add("North", 0);
            this.Cardinality.Add("East", 1);
            this.Cardinality.Add("South", 2);
            this.Cardinality.Add("West", 3);

            Debug.Assert(Name != null);
            Debug.Assert(HP != 0 && MAXHP != 0);
            Debug.Assert(currentRoom != null);
        }

        public void SetRoom(Room room) { this.currentRoom = room; }


        /// <summary>
        /// Method for player to select and attack an enemy in the current room.
        /// </summary>
        /// <returns></returns>
        
        public Enemy Attack ()
        {

            if (currentRoom.Enemies.Count == 0)
            {
                Console.WriteLine("There are no foes nearby.");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return null; 
            }
            Console.WriteLine("Which enemy shall perish?");
            
            foreach (Enemy enemy in currentRoom.Enemies)
            {
                Console.WriteLine($"{currentRoom.Enemies.IndexOf(enemy) + 1}. {enemy.Name}");
            }

            ConsoleKeyInfo choice = Console.ReadKey(); //using consolekeyinfo allows distinction between lower and capital, it doesn't work with my system any other way

            Enemy target = currentRoom.Enemies.ElementAt(Convert.ToInt32(choice.KeyChar.ToString()) - 1);

            return target;

        }

        /// <summary>
        /// Displays room contents.
        /// </summary>
        
        public void Look()
        {
            //display room fluff
            
           

            Console.WriteLine($"This room is {currentRoom.Name} \n");
            Console.WriteLine($"{currentRoom.GetDescription()} \n");

            currentRoom.GetContents();

        }

        /// <summary>
        /// Displays player status and inventory
        /// </summary>

        public void CheckStatus()
        {
            List<string> sort = new();
            sort.Add("Inventory");
            sort.Add("Sword");
            sort.Add("Potion");
            sort.Add("Torch");

            int i = 0;
            

            while (true)
            {
                if (i >= sort.Count) { i = 0; }
                if (i < 0) { i = sort.Count - 1; }
                string pointer = sort[i];
                // Get player health bar

                Console.Write("It's you.");

                    if (this.HP < 50) { Console.ForegroundColor = ConsoleColor.Red; }
                    else              { Console.ForegroundColor = ConsoleColor.Green; }

                    if (this.HP < 25) { Console.WriteLine("Y̸̢̨͉͖̣̖̼̜̟̱̞̫̌ͅò̷̢̺̯̠͓̦̫̣̋̀̄̉̀̔͊̕̕ͅų̸̨̨͎͔̽͝'̸̧̤͓̝̻͖̬̗͖̩̗̩͚̣͑̌̔̒͋͌̾̿̎v̴̧̢͚̆̆̈́͛͠ę̷͌͊͗͐͠ ̴̹͔̯͇͒̇s̶͖͓̲̱̼̙̲̪̼̔͐͜é̸͙̳̜͎̈́͛̒͜ͅẹ̷̺̺͓̹̱̟̘̹͚̺̉̃̓̈́͛͂̌̚ṋ̴̑̂́͜ ̸̧̤̣͕̘̫͚͆͗͒̉́̀ḇ̷̨̞̦̥̯̯͙̖͕͍̲̩͌͘͜͝ȩ̴̨̼̥̩̩̪͎̺͎̤͛́̓̈́̈́̎͊́̍̀̚͘͜͝t̸̹͙̖͎̘̓t̴̺͌̌͐̚ë̵̖̺̘́̊̉͗̍r̷͉͔̪̈́́̇̉̈́̉̌̊̄͐̒̒͘ ̴̡̠̞̪̩̮̻̗̋̀̊̈́͂̈́͒͛̋̍͌̚̕̕d̷̙̰͔̘͇̄͌͌͠ȃ̶̡̢̛̱͖̦̘̫̭͙̟̠̫̭͓̀̀̄̎̃͊͂͛̎̂̈́̕͝y̵̬̹͍͉̼͓̦̗̱̤̙̠̰̟̙̒́͂̎͗̓̔̾̑͊̓̈́ṡ̵̢̳͍̳͍͙͓̆̕͜͜ͅ"); }
                    else              { Console.WriteLine("You've seen better days."); }

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("");
                Console.WriteLine($"You're carrying a {EquippedSword.Name} in your main hand.");
                Console.WriteLine($"You're carrying a {EquippedTorch.Name} in your off hand.");







                Console.WriteLine($"< (q) ============= {pointer} ========== (e) >");

                List<GameItems> items = this.InventoryLinq(pointer);

                foreach (var item in items)
                {
                    Console.Write(items.IndexOf(item) + ". ");
                    Console.WriteLine(item.Name);
                }


                ConsoleKeyInfo choice = Console.ReadKey();
                Console.Clear();

                switch (choice.KeyChar.ToString())
 {
                    case "e": { i++; break; }
                    case "q": { i--; break; }
                    case "i": { return; }
                        
                    default: { continue; }



                }

            }


            }


        /// <summary>
        /// Filters inventory by item types.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>

        public List<GameItems> InventoryLinq(string type)
        {
            if (Inventory.Count == 0)
            {
                Console.WriteLine("Your bag is empty");
                return null;

            }

            if (type == "Inventory")
            { return this.Inventory; }

            List<GameItems> list = new();

            var items = from item in this.Inventory
                        where item.Type == type
                        select item;

            foreach (var item in items)
            { list.Add(item); }    
            


            return list;
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
        /// Moves the player in the specified direction
        /// </summary>
        /// <param name="direction"></param>
        /// <exception cref=">KeyNotFoundException"> </exception>
        
        public void Move(int direction)
        {
            try
            {
                currentRoom = currentRoom.Connections[direction];
                Console.WriteLine("You move forward...");

                if (!currentRoom.IsVisited) { currentRoom.IsVisited = true; }
            }

            catch (KeyNotFoundException)
            {
                Console.WriteLine("There doesn't seem to be anything that way.");
                return;
            }

        }
      
        /// <summary>
        /// Displays map 
        /// </summary>
        /// <param name="Map"></param>
        
        public void CheckMap(Dictionary<int, Room> Map)
        {


            Console.Clear();
            foreach (Room room in Map.Values)
            {
                if (room.IsVisited)
                {
                    Console.Write($"{room.roomID}: ");
                    foreach (Room connectedroom in room.Connections.Values)
                    {
                        if (connectedroom.IsVisited) { Console.Write($"{connectedroom.roomID} "); }
                        else { Console.Write(" ? "); }
                    }
                    
                }
                Console.Write('\n');
            }
            Console.ReadKey();
            

        }
    }
}
