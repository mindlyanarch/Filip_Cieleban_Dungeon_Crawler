using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Map.Rooms.Generic
{
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
}
