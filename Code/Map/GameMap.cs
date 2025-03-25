using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Map
{
    internal class GameMap
    {
        public List<Room> Map;


        
        public EntranceRoom entranceRoom;
        public EmptyRoom room1;
        public GameMap() 
        {
            entranceRoom = new();
            room1 = new();

        Map = new ();
            Map.Add(entranceRoom);
            Map.Add(room1);
    }



    }





}
