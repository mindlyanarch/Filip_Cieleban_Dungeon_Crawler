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
        
        //Master Lists to draw basic and special rooms from

        public Dictionary<int, string> BasicRoomList { get; private set; }
        public Dictionary<int, string> AdvancedRoomList { get; private set; }

        private Random random = new();

        int Floors = 0;
        public GameMap()
        {

            Master = new();
            MasterFloorList = new();

            BasicRoomList = new();
                BasicRoomList.Add(0, "Room_Empty");
                BasicRoomList.Add(1, "Room_Foundry");
                BasicRoomList.Add(2, "Room_Treasure");
                BasicRoomList.Add(3, "Room_Barracks");
                BasicRoomList.Add(3, "Room_Ruined");

            AdvancedRoomList = new();
                AdvancedRoomList.Add(0, "Room_Boss");




        }



        public Dictionary<int, Room> CreateFloor(int size, int difficulty)
        {
            //generate x amount of rooms
            //connect entrance and exit to a room
            //populate rest

            Random random = new();

            Dictionary<int, Room> newFloor = new();

            double Corridor = (size - 1) * 0.6;
            double SpecialRooms = size - Corridor;


            //Generate an entrance first and exit first
            //Every other room goes between

            
            int ID = 1;

            Room_Entrance entrance = new(Floors, 0);
            newFloor.Add(0, entrance); 

            Room_Exit exit = new(Floors, size);
            newFloor.Add(size, exit); 

            // ---------------------------------------
            // ---------------------------------------
            // ---------------------------------------


            //populate floor with Corridor
            while (ID < Corridor)
            {

                newFloor.Add(ID, Create_Room_Basic(Floors, ID)); ID++;

            }

            Corridor_Connect(newFloor);





            while (ID < SpecialRooms)
            {
                //newFloor.Add(ID, Create_Room_Basic(Floors, ID));
                ID++;
            }

            // ---------------------------------------
            // ---------------------------------------
            // ---------------------------------------


        
                MasterFloorList.Add(this.Floors, newFloor);
                this.Floors++;
                return newFloor;
        }

        public Room Create_Room_Basic(int Floors, int ID)

        {
            

            int select = Convert.ToInt32(new Random(BasicRoomList.Count));

            switch (select)
            {
                case 0: { Room_Empty room = new(Floors, ID); return room; }
                case 1: { Room_Foundry room = new(Floors, ID); return room; }
                case 2: { Room_Treasure room = new(Floors, ID); return room; }
                case 3: { Room_Barracks room = new(Floors, ID); return room; }
                case 4: { Room_Ruined room = new(Floors, ID); return room; }
                default: { throw new ArgumentOutOfRangeException(); }
                    
            }
            
            
        }

        public void Corridor_Connect(Dictionary<int, Room> newFloor)
        {

            //Generate a 'corridor' so that entrance and exit are always linked

            for (int i = 0; i < newFloor.Count - 1; i++)
            {
                Room room = newFloor[i];

                int dir = random.Next(room.PossibleConnections - 1);

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

                room.Connections.Add(dir, newFloor[i + 1]);

                //form strong connection between rooms

                dir = random.Next(newFloor[i + 1].PossibleConnections);

                loop = true;
                while (loop)
                {

                    if (newFloor[i + 1].Connections.Count == 0)
                    { break; }

                    foreach (int value in room.Connections.Keys)
                    {

                        if (dir == value)
                        {
                            dir = random.Next(newFloor[i + 1].PossibleConnections - 1);
                        }
                        else
                        {
                            loop = false;
                            break;
                        }
                    }
                }

                newFloor[i + 1].Connections.Add(dir, room);
                //Iterate through each room until all connections are done

            }

        }
    }


}






