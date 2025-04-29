using DungeonExplorer.Code.Items.Swords;
using DungeonExplorer.Code.Map.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    internal class Testing


    {

        public Testing(Player player) 
        { Player playerTarget = player; }
        /// <summary>
        /// Calls debug menu options
        /// </summary>
        /// <param name="game"></param>
        public void DebugMenu(Game game, Player playerTarget)
        {

            Console.WriteLine("1. Spawn Item");
            string input = Console.ReadLine()?.ToLower();

            switch (input)
            {
                case "1":
                    {
                        SpawnItem(game, playerTarget); 
                            break; }

                default:
                    break;
            }
        }

        /// <summary>
        /// Spawns an item
        /// </summary>
        /// <param name="game"></param>
        private void SpawnItem(Game game, Player playerTarget)
        {
            Console.WriteLine("Which item?");
            Console.WriteLine("1.Rusty Sword");

            string input = Console.ReadLine()?.ToLower();

            switch (input)
            {
                case "1":
                    {
                        Sword rustySword = new Sword("Rusty Sword", "This has been here a long time...", 5);

                        Room destination = playerTarget.GetRoom();

                        destination.Inventory.Add(rustySword);


                        break;
                    }
                default:
                    { 
                        break; }

            }
        }
    }


}
