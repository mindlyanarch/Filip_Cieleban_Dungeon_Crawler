using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Map.Rooms.Unique
{
    internal class Room_Boss : Room
    {
        public Room_Boss(int Floor, int ID)
        {
            roomFloor = Floor;
            roomID = ID;
            Name = "Lair";
            Description = "You can sense the presence of a powerful foe in this room.";
            PossibleConnections = 4;
            PossibleTraps = 4;
            roomLevel = 0;
        }


    }
}
