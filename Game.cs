using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Media;
using System.Numerics;
using System.Text.RegularExpressions;

namespace DungeonExplorer
{
    internal class Game
    {

        //Declare objects:

        //player
        private Player player;

        //Rooms
        private EntranceRoom entranceRoom;
        private EmptyRoom room1;

        //Enemies
        private Creatures.Rat rat;

        //Map
        public List<Room> Map;

        public Testing testing;


        public Game()
        {
            // Initialize Objects:


            //Rooms
            entranceRoom = new();
            room1 = new();


            //Player
            Console.WriteLine("What is your name?");
            string input = Console.ReadLine();



            player = new(input, 100, entranceRoom);

            //Enemies
            entranceRoom.Enemies.Add(rat = new(entranceRoom));

            Map = new();
            Map.Add(entranceRoom);
            Map.Add(room1);

            testing = new Testing();
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                //Player turn:

                Console.WriteLine("It's cold in here...");

                Console.WriteLine("Type 'look' to check where you are, or 'exit' to quit.");
                Console.WriteLine("Type 'inventory' to check your bag, or 'Pickup' to grab an item");
                Console.WriteLine("Type 'forward' or 'backward' to move");
                string input = Console.ReadLine()?.ToLower();

                switch (input)
                {
                    case "look": { player.Look(); break; }
                    case "inventory": { player.GetInventory(); break; }
                    case "pickup": { player.PickUpItem(); break; }
                    case "forward": { player.Move_Forward(Map); break; }
                    case "backward": { player.Move_Backward(Map); break; }
                    case "exit": { playing = false; break; }
                    case "debug": { testing.DebugMenu(this); break; }
                    default:
                    {
                        Console.Write("That doesn't seem to be a ");
                        Console.WriteLine("valid command, try again:");
                        continue;
                    }

                }

                if (!playing)
                { break; }

                Console.WriteLine("press any key to continue.");
                Console.ReadKey();
                Console.Clear();

                //Game processing:


            }
        }

        public Player GetPlayer()
        {
            return this.player;
        }
    }
}