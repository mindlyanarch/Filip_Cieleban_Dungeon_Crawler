using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class GameMap
    {
        public Dictionary<string, Room> Master { get; private set; }

        public Dictionary<int, Dictionary<int, Room>> MasterFloorList { get; private set; }

        private Random random = new();


        public List<List<Room>> MapLevel_0;
        public List<Room> Map;
        //Hard coded mandatory rooms
        public EntranceRoom entranceRoom_0;
        public EntranceRoom entranceRoom_1;
        public EntranceRoom entranceRoom_2;

        public ExitRoom exitRoom_0;
        public ExitRoom exitRoom_1;
        public ExitRoom exitRoom_2;

        //temp for testing

        EmptyRoom EmptyRoom1;
        EmptyRoom EmptyRoom2;
        EmptyRoom EmptyRoom3;
        EmptyRoom EmptyRoom4;
        EmptyRoom EmptyRoom5;
        EmptyRoom EmptyRoom6;
        EmptyRoom EmptyRoom7;

        int Floors = 0;
        public GameMap()
        {

            Master = new();
            MasterFloorList = new();

            //Hard coded mandatory rooms


            //temp for testing


            Room[,] MapLevel_1 = new Room[3, 3];
            Room[,] MapLevel_2 = new Room[3, 3];

            MapLevel_0 = new();
            List<Room> Row1 = new();
            List<Room> Row2 = new();
            List<Room> Row3 = new();

            MapLevel_0.Add(Row1);
            Row1.Add(EmptyRoom1);
            Row1.Add(entranceRoom_0);
            Row1.Add(EmptyRoom2);

            MapLevel_0.Add(Row2);
            Row1.Add(EmptyRoom3);
            Row1.Add(EmptyRoom4);
            Row1.Add(EmptyRoom5);

            MapLevel_0.Add(Row3);
            Row1.Add(EmptyRoom6);
            Row1.Add(exitRoom_0);
            Row1.Add(EmptyRoom7);

        }

        public void DisplayMap()
        {
            Console.Clear();

            List<String> MapStack = new();

            foreach (List<Room> Row in MapLevel_0)
            {

                foreach (Room room in Row)
                {
                    if (room.IsVisited == false)
                    {
                        MapStack.Add(" O ");
                        MapStack.Add("=");
                    }

                    if (room.IsVisited == true)
                    {
                        MapStack.Add(" X ");
                        MapStack.Add("=");
                    }

                }
                MapStack.Add("\\n");
            }

            string output = String.Join("", MapStack);
            Console.WriteLine(output);
            Console.ReadKey();
        }


        public Dictionary<int, Room> CreateFloor(int size, int difficulty)
        {
            //generate x amount of rooms
            //connect entrance and exit to a room
            //populate rest

              Dictionary<int, Room> newFloor = new();

            //Generate an entrance and exit first
            int ID = 0;

            EntranceRoom entrance = new(Floors, ID);
            newFloor.Add(ID, entrance); ID++;

            ExitRoom exit = new(Floors, ID);
            newFloor.Add(ID, exit); ID++;


            //populate rest of floor
            while (ID < size)
            {
                EmptyRoom room = new(Floors, ID);
                newFloor.Add(ID, room); ID++;

            }


            MasterFloorList.Add(this.Floors, newFloor);
            this.Floors++;

            return newFloor;
        }


    }


}






