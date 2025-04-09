using System;
using System.Collections.Generic;
using System.Drawing;

namespace DungeonExplorer
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
        public List<Creature> Enemies { get; protected set; }
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
            if (this.Inventory.Count == 0)
            {
                Console.WriteLine("There's nothing here");

            }
            else
            {
                Console.WriteLine("This room contains:");

                foreach (GameItems item in this.Inventory)
                {
                    Console.Write(this.Inventory.IndexOf(item) + 1 + ". ");
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

    internal class Room_Empty : Room
    {
        public Room_Empty(int Floor, int ID)
        {
            roomFloor = Floor;
            roomID = ID;
            Name = "An empty Room";
            Description = "One of many, there doesn't seem to be anything notable here.";
            PossibleConnections = 4;
            PossibleTraps = 4;
            roomLevel = 1;
        }


    }
    internal class Room_Foundry : Room
    {
        public Room_Foundry(int Floor, int ID)
        {
            roomFloor = Floor;
            roomID = ID;
            Name = "Foundry";
            Description = "Your imagination can still feel the heat in the forges.";
            PossibleConnections = 4;
            PossibleTraps = 4;
            roomLevel = 1;

        }


    }
    internal class Room_Treasure : Room
    {
        public Room_Treasure(int Floor, int ID)
        {
            roomFloor = Floor;
            roomID = ID;
            Name = "Vault";
            Description = "The room is littered with artifacts, which indicate this room was once important.";
            PossibleConnections = 4;
            PossibleTraps = 4;
            roomLevel = 2;
        }


    }
    internal class Room_Barracks : Room
    {
        public Room_Barracks(int Floor, int ID)
        {
            roomFloor = Floor;
            roomID = ID;
            Name = "Barracks";
            Description = "People lived here once.";
            PossibleConnections = 4;
            PossibleTraps = 4;
            roomLevel = 3;
        }


    }
    internal class Room_Ruined : Room
    {
        public Room_Ruined(int Floor, int ID)
        {
            roomFloor = Floor;
            roomID = ID;
            Name = "Ruins";
            Description = "Whatever this room used to contain is buried under rubble.";
            PossibleConnections = 4;
            PossibleTraps = 4;
            roomLevel = 0;

        }


    }

    //Rooms that should be one-of-a-kind.

    internal class Room_Entrance : Room
    {
        public Room_Entrance(int Floor, int ID)
        {
            roomID = ID;
            roomFloor = Floor;
            Name = "Entrance Hall";
            Description = "Behind you lies a massive stone gate. There is no return.";
            IsVisited = true; // this should always be true 
            PossibleConnections = 1;
            PossibleTraps = 0;
            roomLevel = 0;
        }
    }
    internal class Room_Exit : Room
    {
        public Room_Exit(int Floor, int ID)
        {
            roomID = ID;
            roomFloor = Floor;
            Name = "Stairwell";
            Description = "The descent continues.";
            IsVisited = true; //this should always be true
            PossibleConnections = 1;
            PossibleTraps = 0;
            roomLevel = 0;
        }
    }
    internal class Room_Puzzle : Room
    {
        public Room_Puzzle(int Floor, int ID)
        {
            roomFloor = Floor;
            roomID = ID;
            Name = "Shrine";
            Description = "A shrine dedicated to one of the gods of this realm.";
            PossibleConnections = 4;
            PossibleTraps = 4;
            roomLevel = 0;
        }


    }
    internal class Room_Boss : Room
    {
        public Room_Boss(int Floor, int ID)
        {
            roomFloor = Floor;
            roomID = ID;
            Name = "Lair";
            Description = "You can sense the presence of a powerful foe in this room.";
            PossibleConnections = 4;
            PossibleTraps = 4;
            roomLevel = 0;
        }


    }

}

