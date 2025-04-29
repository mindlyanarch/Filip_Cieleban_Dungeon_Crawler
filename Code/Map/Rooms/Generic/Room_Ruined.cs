using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Map.Rooms.Generic
{
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
}
