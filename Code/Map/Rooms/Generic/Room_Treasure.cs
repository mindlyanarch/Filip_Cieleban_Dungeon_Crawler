using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Map.Rooms.Generic
{
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
}
