using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Map.Rooms.Generic
{
    internal class Room_Foundry : Room
    {
        public Room_Foundry(int Floor, int ID)
        {
            roomFloor = Floor;
            roomID = ID;
            Name = "Foundry";
            Description = "Your imagination can still feel the heat in the forges.";
            PossibleConnections = 4;
            PossibleTraps = 4;
            roomLevel = 1;

        }


    }
}
