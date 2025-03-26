using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
   
        public abstract class Room
    {
        public int ID { get; protected set; }
        public string Description { get; protected set; }
        public string Name { get; protected set; }
        internal List<Creature> Enemies { get => enemies; set => enemies = value; }
        

        public List<GameItems> Inventory = new();
        private List<Creature> enemies = new();

        public Room()
        {
            Name = "The Void";
            Description = "You shouldn't be here.";

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
        public EntranceRoom()
        {
            ID = 0;
            Name = "Entrance Hall";
            Description = "Behind you lies a massive stone gate. There is no return.";

        }


    }

}