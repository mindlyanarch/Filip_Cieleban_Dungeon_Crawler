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



            testing = new Testing(player);

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

                Display_Commands(command);
                ConsoleKeyInfo choice = Console.ReadKey();
                Console.Clear();

                switch (choice.KeyChar.ToString())
                {

                    case "l": { player.Look(); break; }
                    case "i": { player.GetInventory(); break; }
                    case "p": { player.PickUpItem(); break; }

                    case "w": { player.Move("North", gameMap.Map); break; }
                    case "a": { player.Move("West", gameMap.Map); break; }
                    case "s": { player.Move("South", gameMap.Map); break; }
                    case "d": { player.Move("East", gameMap.Map); break; }

                    case "q": { playing = false; break; }
                    case "m": { testing.DebugMenu(this, player); break; }

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

        public void Display_Commands(Command command)
        {
            byte max = Math.Max(Convert.ToByte(command.playing.Count), Convert.ToByte(this.info.Count));

            for (int i = 0; i < max; i++)
            {
                string column1 = (i < info.Count) ? info[i] : "";
                string column2 = (i < command.playing.Count) ? command.playing[i] : "";

                Console.WriteLine("{0, -100}, {1} ", column1, column2);
            }
        }
    }
}