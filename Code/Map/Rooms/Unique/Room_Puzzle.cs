using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Map.Rooms.Unique
{
    internal class Room_Puzzle : Room
    {
        public Room_Puzzle(int Floor, int ID)
        {
            roomFloor = Floor;
            roomID = ID;
            Name = "Shrine";
            Description = "A shrine dedicated to one of the gods of this realm.";
            PossibleConnections = 4;
            PossibleTraps = 4;
            roomLevel = 0;
        }


    }
}
