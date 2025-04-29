using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Map.Rooms.Generic
{
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
}
