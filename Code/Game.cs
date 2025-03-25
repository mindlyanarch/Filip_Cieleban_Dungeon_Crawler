using DungeonExplorer.Code.Map;
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

        private GameMap gameMap;
        private List<string> info;
        //Enemies
        private Creatures.Rat rat;

        public Testing testing;
        public Command command;

        public Game()
        {
            // Initialize Objects:


            //Rooms

            command = new();
            //Player
            Console.WriteLine("What is your name?");
            string input = Console.ReadLine();

            gameMap = new();

            player = new(input, 100, gameMap.entranceRoom);

            //Enemies
            //entranceRoom.Enemies.Add(rat = new(entranceRoom));



            testing = new Testing();

            info = new();

            info.Add("It's cold in here");
            info.Add(player.currentRoom.Name);
            info.Add(player.currentRoom.Description);

        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                //Player turn:

                for (int i = 0;  i < command.playing.Count - 1; i++)
                {
                    Console.WriteLine(string.Format("{0, -50} {1, 50}  ",
                                                    info[i],
                                                    command.playing[i]));
                }
                string input = Console.ReadLine()?.ToLower();

                switch (input)
                {
                    case "look": { player.Look(); break; }
                    case "inventory": { player.GetInventory(); break; }
                    case "pickup": { player.PickUpItem(); break; }
                    case "forward": { player.Move_Forward(gameMap.Map); break; }
                    case "backward": { player.Move_Backward(gameMap.Map); break; }
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
            return player;
        }
    }
}