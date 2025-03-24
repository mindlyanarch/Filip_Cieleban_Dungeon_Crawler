using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{

    //Program name: Dungeon Explorer
    //Author: Filip Cieleban (29086791)

    internal class Program
    {
        static void Main(string[] args)
        {

            //Room to implement a main menu and save function


            Game game = new Game();
            game.Start();


            //Code will proceed to exit game once Playing loop ends

            Console.WriteLine("Closing the game...");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
