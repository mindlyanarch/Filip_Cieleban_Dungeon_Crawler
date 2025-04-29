using System;
using System.Collections.Generic;
using System.Drawing;

namespace DungeonExplorer.Code.Map.Rooms
{

    public abstract class Room

    {
        //general room characteristics
        public int roomID { get; protected set; }
        public int roomFloor { get; protected set; }
        public string Description { get; protected set; }
        public string Name { get; protected set; }

        //Object libraries
        public Dictionary<int, Room> Connections { get; protected set; }
        public int PossibleConnections { get; protected set; }
        public List<Enemy> Enemies { get; protected set; }
        public List<GameItems> Inventory { get; protected set; }
        //public List<Trap> Traps { get; protected set; }
        //public List<Shrines> shrines { get; protected set; }



        //Game Engine fields
        public int roomLevel { get; protected set; }
        public bool IsVisited { get; set; }
        public int PossibleTraps { get; protected set; }
        public int Loot = 0;

        public Room()
        {
            Name = "The Void";
            Description = "You shouldn't be here.";
            Inventory = new();
            Enemies = new();


            roomLevel = -1;
            PossibleTraps = 0;
            Loot = 0;

            IsVisited = false;
            Connections = new();
        }
        /// <summary>
        /// reads out room inventory.
        /// </summary>
        public void GetContents()
        {
            if (Inventory.Count == 0)
            {
                Console.WriteLine("There's nothing here");

            }
            else
            {
                Console.WriteLine("This room contains:");

                foreach (GameItems item in Inventory)
                {
                    Console.Write(Inventory.IndexOf(item) + 1 + ". ");
                    Console.WriteLine(item.Name);
                }
            }
        }

        public string GetDescription() { return Description; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetID() { return roomID; }
    }



    //"Corridor" rooms.







    //Rooms that should be one-of-a-kind.

  
  
   
   

}

