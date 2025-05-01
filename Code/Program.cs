using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DungeonExplorer;


namespace DungeonExplorer
{

    //Program name: Dungeon Explorer
    //Author: Filip Cieleban (29086791)

    internal class Program
    {

        

        static void Main(string[] args)
        {

            //Initialize Core Functions:

            ProgramDisplay display = new(); //handles screen size
            display.Init(); 

            Game game = new(); //core gameplay object
            DataController controller = new(); // handles saves

            while (true)
            {
                //Main Menu
                Console.WriteLine("Welcome to Dungeon Crawler!");
                Console.WriteLine("Pick an option:\n");

                Console.WriteLine("a. Start new game");

                Console.WriteLine("q. Exit");

                ConsoleKeyInfo choice = Console.ReadKey();
                Console.Clear();

                switch (choice.KeyChar.ToString())
                {
                    case "a": { Program.Start(game); break; }
                    case "q": { Program.Quit(); break; }
                    default: { continue; }
                }
            }
        }

        static void Start(Game game)
        {
            Console.WriteLine("Long ago, in the distance future, darkness looms.");
            Console.Write("It is up to you to head into the dungeon and stop the evil sorcerer");
            Console.WriteLine(" before he awakens...\n");

            Console.Write("press any key to continue.");
            Console.ReadKey();
            Console.Clear();

            game.Start();
        }

        static void Quit()
        {
            Console.WriteLine("Closing the game...");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }



    }
}
