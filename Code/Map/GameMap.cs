using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    internal class GameMap
    {
        public Dictionary<string, Room> Master { get; private set; }

        public Dictionary<int, Dictionary<int, Room>> MasterFloorList { get; private set; }

        private Random random = new();

        int Floors = 0;
        public GameMap()
        {

            Master = new();
            MasterFloorList = new();

            //Hard coded mandatory rooms


            //temp for testing




        }

        /*
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
        */

        public Dictionary<int, Room> CreateFloor(int size, int difficulty)
        {
            //generate x amount of rooms
            //connect entrance and exit to a room
            //populate rest

              Dictionary<int, Room> newFloor = new();

            //Generate an entrance and exit first
            int ID = 0;

            Room_Entrance entrance = new(Floors, ID);
            newFloor.Add(ID, entrance); ID++;



            //populate rest of floor
            while (ID < size - 1)
            {
                Room_Empty room = new(Floors, ID);
                newFloor.Add(ID, room); ID++;

            }

            Room_Exit exit = new(Floors, ID);
            newFloor.Add(ID, exit); ID++;

            Random random = new();


            //Generate a 'corridor' so that entrance and exit are always linked


            for (int i = 0; i < newFloor.Count - 1; i++)
            {
                Room room = newFloor[i]; 

                int dir = random.Next(room.PossibleConnections -1);

                bool loop = true;
                while (loop)
                {

                    if (room.Connections.Count == 0)
                    { break; }

                    foreach (int value in room.Connections.Keys)
                    {


                        if (dir == value)
                         {
                            dir = random.Next(room.PossibleConnections - 1);
                         }
                        else
                        {
                            loop = false;
                            break;
                        }
                    }
                }

                room.Connections.Add(dir, newFloor[i+1]);

                //form strong connection between rooms

                dir = random.Next(newFloor[i+1].PossibleConnections);

                loop = true;
                while (loop)
                {

                    if (newFloor[i + 1].Connections.Count == 0)
                    { break; }

                    foreach (int value in room.Connections.Keys)
                    {

                        if (dir == value)
                        {
                            dir = random.Next(newFloor[i+1].PossibleConnections - 1);
                        }
                        else
                        {
                            loop = false;
                            break;
                        }
                    }
                }

                newFloor[i + 1].Connections.Add(dir,room);
                //Iterate through each room until all connections are done

            }


           
                MasterFloorList.Add(this.Floors, newFloor);
                this.Floors++;
                return newFloor;
        }


    }


}






