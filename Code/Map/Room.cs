using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
   
        public abstract class Room
    {
        public int ID { get; protected set; }
        public string Description { get; protected set; }
        public string Name { get; protected set; }
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
        public int GetID() { return ID; }
    }

    public class EmptyRoom : Room
    {
        public EmptyRoom()
        {
            ID = 1;
            Name = "An empty Room";
            Description = "One of many, there doesn't seem to be anything notable here.";

        }


    }
    public class EntranceRoom : Room
    {
        public EntranceRoom(int level)
        {
            ID = 0;
            Name = "Entrance Hall";
            Description = "Behind you lies a massive stone gate. There is no return.";
            roomLevel = level;
            IsVisited = true; // this should always be true 
        }
    }

    public class ExitRoom : Room
    {
        public ExitRoom(int level)
        {
            ID = 0;
            Name = "Entrance Hall";
            Description = "Behind you lies a massive stone gate. There is no return.";
            roomLevel = level;
            IsVisited = true; //this should always be true

        }
    }

}