using System;
using System.Collections.Generic;
using System.Drawing;

namespace DungeonExplorer
{
   
        public abstract class Room
    {
        public int roomID { get; protected set; }
        public int roomFloor {  get; protected set; }
        public string Description { get; protected set; }
        public string Name { get; protected set; }

        public Dictionary<int, Room> Connections { get; protected set; }
        public int PossibleConnections { get; protected set; }
        public List<Creature> Enemies { get; protected set; }
        public List<GameItems> Inventory { get; protected set; }
        
        public int roomLevel { get; protected set; }

        public bool IsVisited { get; protected set; }


        public Room()
        {
            Name = "The Void";
            Description = "You shouldn't be here.";
            Inventory = new();
            Enemies = new();
             roomLevel = -1;
            IsVisited = false;
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


    public class EntranceRoom : Room
    {
        public EntranceRoom(int Floor, int ID)
        {
            roomID = ID;
            roomFloor = Floor;
            Name = "Entrance Hall";
            Description = "Behind you lies a massive stone gate. There is no return.";
            IsVisited = true; // this should always be true 
            PossibleConnections = 1;
            Connections = new();
        }
    }

    public class ExitRoom : Room
    {
        public ExitRoom(int Floor, int ID)
        {
            roomID = ID;
            roomFloor = Floor;
            Name = "Entrance Hall";
            Description = "Behind you lies a massive stone gate. There is no return.";
            IsVisited = true; //this should always be true
            PossibleConnections = 1;
            Connections = new(); 
        }
    }
    public class EmptyRoom : Room
    {
        public EmptyRoom(int Floor, int ID)
        {
            roomFloor = Floor;
            roomID = ID;
            Name = "An empty Room";
            Description = "One of many, there doesn't seem to be anything notable here.";
            PossibleConnections = 4;
            Connections = new();
        }


    }

}