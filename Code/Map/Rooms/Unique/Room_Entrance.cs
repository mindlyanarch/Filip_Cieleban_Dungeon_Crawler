using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer.Code.Items.Potions;

namespace DungeonExplorer.Code.Map.Rooms.Unique
{
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
            Potion potion = new();
            Inventory.Add(potion);
        }
    }
}
