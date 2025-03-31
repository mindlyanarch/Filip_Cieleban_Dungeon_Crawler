using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Map
{
    internal class GameMap
    {
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

        public GameMap()
        {
            //Hard coded mandatory rooms
            entranceRoom_0 = new(0);
            entranceRoom_1 = new(1);
            entranceRoom_2 = new(2);

            exitRoom_0 = new(0);
            exitRoom_1 = new(1);
            exitRoom_2 = new(2);

            //temp for testing

            EmptyRoom1 = new();
            EmptyRoom2 = new();
            EmptyRoom3 = new();
            EmptyRoom4 = new();
            EmptyRoom5 = new();
            EmptyRoom6 = new();
            EmptyRoom7 = new();



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

        


    }



    }






