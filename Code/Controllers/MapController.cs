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

        public MapController() { Map = new(); }





        public void CreateFloor(int size, int difficulty)

        {
            this.Map.CreateFloor(size, difficulty);


        }






    }



}
