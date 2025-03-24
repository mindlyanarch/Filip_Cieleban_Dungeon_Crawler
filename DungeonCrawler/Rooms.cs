using static DungeonCrawler.GameItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class Rooms
    {
        public abstract class Room
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public string Name { get; set; }

            public List<GameItem> Inventory = new();

            public Room()
            {
                Name = "The Void";
                Description = "You shouldn't be here.";

            }
        }

        public class EmptyRoom : Room
        {
            public EmptyRoom()
            {
                Name = "An empty Room";
                Description = "One of many, there doesn't seem to be anything notable here.";

            }


        }
        public class EntranceRoom : Room
        {
            public EntranceRoom()
            {
                Id = 001;
                Name = "Entrance Hall";
                Description = "Behind you lies a massive stone gate. There is no return.";

            }


        }



    }
}
