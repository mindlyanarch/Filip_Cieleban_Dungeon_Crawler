using DungeonExplorer.Code.Map.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DungeonExplorer
{


    internal class MapController : Controller
    {




        //This map controller handles all communication related to position.

        public GameMap Map {get; private set;}
        public int CurrentLevel {get; private set;}
        public int Currentdifficulty {get; private set;}
        public Dictionary<int, Room> CurrentFloor { get; private set;} 



        public MapController()
        {
            Map = new();

            CurrentLevel = 0;
            

            

        }

        public Dictionary<int, Room> SetCurrentFloor(Dictionary<int, Room> map)
        {
            CurrentFloor = map;
            return CurrentFloor;
        }



        public Dictionary<int, Room> CreateFloor(int size, int difficulty, CreatureController creatureController)

        {
            Dictionary<int, Room> newFloor = this.Map.CreateFloor(size, difficulty);

            creatureController.PopulateFloor(newFloor);
            //creatureController.PopulateFloor(newFloor, difficulty);
            return newFloor;
        }






    }



}
