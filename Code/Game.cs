using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
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
        //Enemies
        private Rat rat;

        public Testing testing;
        public Command command;

        private DisplayController displayController;
        private CreatureController enemyController;
        private MapController mapController;

        public Game()
        {
            // Initialize Objects:

            //controllers

            displayController = new(this); //handles screen output 
            enemyController = new();
            mapController = new();

            mapController.CreateFloor(9, 0);


            command = new();
            testing = new Testing(player);

            //Rooms

            player = new();



        }
        public void Start()
        {

            player.currentRoom = mapController.CurrentFloor[0];


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

  

                    case "w": { player.Move(0); break; }
                    case "a": { player.Move(1); break; }
                    case "s": { player.Move(2); break; }
                    case "d": { player.Move(3); break; }

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

