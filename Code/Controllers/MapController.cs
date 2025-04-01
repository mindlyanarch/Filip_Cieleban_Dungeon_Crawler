using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{


    internal class MapController
    {
        //This map controller handles all communication related to position.

        public GameMap Map {get; private set;}

        public int CurrentLevel {get; private set;}

        public Dictionary<int, Room> CurrentFloor { get; private set;} 

        public MapController()
        {
            Map = new();

            CurrentLevel = 0;

            CurrentFloor = new(CreateFloor(9,0));

        }





        public Dictionary<int, Room> CreateFloor(int size, int difficulty)

        {
            Dictionary<int, Room> newFloor = this.Map.CreateFloor(size, difficulty);

            return newFloor;
        }






    }



}
