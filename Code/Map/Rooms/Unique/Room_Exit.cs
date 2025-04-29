using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Map.Rooms.Unique
{
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
}
