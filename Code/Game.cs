using DungeonExplorer.Code.Creatures.Enemies;
using DungeonExplorer.Code.Data;
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
        public Statistics stats;
        public Testing testing;
        public Command command;

        private List<Controller> controllerList;
        private DisplayController displayController;
        private CreatureController creatureController;
        private MapController mapController;

        public Game()
        {
            // Initialize Objects:

            //controllers

            controllerList= new();

                controllerList.Add(displayController = new()); //handles screen output 
                controllerList.Add(creatureController = new());//handles enemies
                controllerList.Add(mapController = new()); //handles rooms

            foreach (var controller in controllerList) 
            {controller.Get_Controller_List(controllerList); }

            mapController.SetCurrentFloor(mapController.CreateFloor(9, 0, creatureController));
            

            command = new();
            testing = new Testing(player);

            //Rooms

            player = new();



        }
        public void Start()
        {

            player.SetRoom(mapController.CurrentFloor[0]);

            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                //Player turn:

                displayController.Update(this);
                displayController.Display_Main(command);


                ConsoleKeyInfo choice = Console.ReadKey(); //using consolekeyinfo allows distinction between lower and capital, it doesn't work with my system any other way
                Console.Clear();

                switch (choice.KeyChar.ToString())
                {

                    case "l": { player.Look(); break; }
                    case "i": { player.CheckStatus(); break; }


                    case "p": { player.PickUpItem(); break; }
                    case "m": { player.CheckMap(mapController.CurrentFloor); break; }

                    case "f":
                        {
                            Enemy target = player.Attack();

                            if (target == null) { break; }
                            bool dead = target.TakeDamage(player.EquippedSword.Damage);

                            if (dead)
                            { creatureController.Kill(target, player.currentRoom); }

                            break;
                        }

                    case "w": { player.Move(0); break; }
                    case "a": { player.Move(3); break; }
                    case "s": { player.Move(2); break; }
                    case "d": { player.Move(1); break; }

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



                //Game processing:
                creatureController.GetEnemies(player.currentRoom);
                creatureController.EnemyTurn(player);

                Console.WriteLine("press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }


        
    }
}

