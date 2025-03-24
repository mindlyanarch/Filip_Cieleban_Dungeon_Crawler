using System;
using System.Collections.Generic;
using System.Linq;
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

            Game game = new();
            DataController controller = new();


            //Main Menu
            Console.WriteLine("Welcome to Dungeon Crawler!");
            Console.WriteLine("Pick an option:\n");

            Console.WriteLine("1. Start new game");

            Console.WriteLine("0. Exit");

            string choice = PlayerChoice();

            switch (choice)
            {
                case "a": { Program.Start(); break;}
            }
            Console.WriteLine("It is up to you to head into the dungeon and stop the evil sorcerer");
            Console.WriteLine(" before he awakens.");

            Console.WriteLine("Long ago, in the distance future, darkness looms:");





            game.Start();


            //Code will proceed to exit game once Playing loop ends

            Console.WriteLine("Closing the game...");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
