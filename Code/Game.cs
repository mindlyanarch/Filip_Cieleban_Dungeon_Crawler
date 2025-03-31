using DungeonExplorer;
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
        public Player player { get; private set; }

        private GameMap gameMap;
        private List<string> info;
        //Enemies
        private Rat rat;

        public Testing testing;
        public Command command;
        DisplayController displayController;
        EnemyController enemyController;
        public Game()
        {
            // Initialize Objects:

            //Display

            displayController = new(this); //handles screen output
            enemyController = new();
            //Rooms

            command = new();


            gameMap = new(); //handles location
            player = new("hero", 100, gameMap.entranceRoom_0);


            //Enemies




            testing = new Testing(player);



        }
        public void Start()
        {
            //Player
            Console.WriteLine("What is your name?");
            string input = Console.ReadLine();



            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                //Player turn:

                displayController.Update(this);
                displayController.Display_Main(command);


                ConsoleKeyInfo choice = Console.ReadKey();
                Console.Clear();

                switch (choice.KeyChar.ToString())
                {

                    case "l": { player.Look(); break; }
                    case "i": { player.GetInventory(); break; }
                    case "p": { player.PickUpItem(); break; }

                    case "m": { gameMap.DisplayMap(); break; }

                    case "w": { player.Move("North", gameMap.Map); break; }
                    case "a": { player.Move("West", gameMap.Map); break; }
                    case "s": { player.Move("South", gameMap.Map); break; }
                    case "d": { player.Move("East", gameMap.Map); break; }

                    case "q": { playing = false; break; }
                    case "n": { testing.DebugMenu(this, player); break; }

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
                enemyController.GetEnemies(player);
                enemyController.EnemyTurn();

            }
        }


        
    }
}

