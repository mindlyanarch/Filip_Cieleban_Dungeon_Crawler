using DungeonExplorer.Code.Map.Rooms;
using DungeonExplorer.Code.Map.Rooms.Generic;
using DungeonExplorer.Code.Map.Rooms.Unique;
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
            BasicRoomList.Add(4, "Room_Ruined");

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

            int Corridor = Convert.ToInt32((size - 1) * 0.6);
            int SpecialRooms = size - Corridor;



            


            int ID = 0;

            Generate_Corridor(newFloor, ref ID, ref Corridor);





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
        /// <summary>
        /// Creates a new room with <paramref name="ID"/> on current Floor.
        /// </summary>
        /// <param name="Floors"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Room Create_Room_Basic(int Floors, int ID)

        {

            Random random = new();
            int select = random.Next(BasicRoomList.Count);

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

        /// <summary>
        /// Connects all rooms in the floor linearly.
        /// </summary>
        /// <param name="newFloor"></param>
        public void Generate_Corridor(Dictionary<int, Room> newFloor, ref int ID, ref int Corridor)
        { 

            while (ID <= Corridor)
            {
                if (ID == 0)
                {
                    
                  Room_Entrance entrance = new(Floors, ID);  //create entrance room as the first room
                  newFloor.Add(ID, entrance); ID++;

                  Room next = Create_Room_Basic(Floors, random.Next(BasicRoomList.Count));
                    newFloor.Add(ID, next); ID++;

                  Connect_Rooms(entrance, next, newFloor);
                  
                }

                else if (ID == Corridor)
                {
                    Room_Exit exit = new(Floors, ID);
                    newFloor.Add(ID, exit);
                    while (true)
                    {
                        int next = random.Next(newFloor.Count);

                        if (newFloor[next] == exit) { continue; }
                        if (newFloor[next].Connections.Count != newFloor[next].PossibleConnections)
                        {
                            Connect_Rooms(exit, newFloor[next], newFloor); ID++;
                            break;
                        }
                    }

                }

                else
                {
                    Room room = Create_Room_Basic(Floors, random.Next(BasicRoomList.Count));
                    newFloor.Add(ID, room); ID++;

                    while (true)
                    {
                        int next = random.Next(newFloor.Count);

                        if (newFloor[next] == room) { continue; }

                        if (newFloor[next].Connections.Count != newFloor[next].PossibleConnections)
                        {
                            Connect_Rooms(room, newFloor[next], newFloor);
                            break;
                        }
                    }
                }

            }
            
            

            
           
        }


        /// <summary>
        /// Connect one room to another.
        /// </summary>
        /// <param name="room"></param>
        /// <param name="next"></param>
        /// 
        public void Connect_Rooms(Room current, Room next, Dictionary<int, Room> newFloor)
        {
            Random random = new();

            int dir;
            int dirOpp;

            while (true)

            //check if current and next room connections have space.
            {
                dir = random.Next(4);
                dirOpp = Cardinality.GetOppositeDirection(dir);
                try
                {
                    if (!current.Connections.ContainsKey(dir)  & !next.Connections.ContainsKey(dirOpp))
                    {
                        current.Connections.Add(dir, next);

                        next.Connections.Add(dirOpp, current);
                        break;
                    }
                }
                catch (KeyNotFoundException) { continue; }
            }

        }

        //Generate a 'corridor' so that entrance and exit are guaranteed always linked




        /*
        for (int i = 0; i < newFloor.Count; i++)
        {
            Room room = newFloor[i];

            int dir = random.Next(room.PossibleConnections);

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
        */
    }
}









