using System;
using System.Collections.Generic;
using System.Data;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class DisplayController() : Controller
    {

        public List<string> info { get; private set; }
        public int torchLevel { get; private set; }



        private Game gameObject { get; set; }


        public DisplayController(Game game) : this()

        {
            gameObject = game;
            info = new();

        }

        public List<string> Update(Game game)
        {
            Cardinality cardinal = new();
            if (!(game.player.EquippedTorch == null))
            {
                this.info = game.player.EquippedTorch.SetLight(game.player);

                foreach (var connection in game.player.currentRoom.Connections.Keys)
                {
                    this.info.Add($"There is an exit leading {cardinal.GetCardinalString(connection)}.");
                }
                return info;
            }
            else 
            {
                this.info = new();
                info.Add("It's cold in here...");
                return info;
            }
        }
        
        public void Display_Main(Command command)
        {
            //logic to display main game data in columns

            byte max = Math.Max(Convert.ToByte(command.playing.Count), Convert.ToByte(this.info.Count));

            for (int i = 0; i < max; i++)
            {
                string column1 = (i < info.Count) ? info[i] : "";
                string column2 = (i < command.playing.Count) ? command.playing[i] : "";

                Console.WriteLine("{0, -100}, {1} ", column1, column2);
            }
        }

        public void Display_Status(Command command)
        {


            Console.Write("It's you.");

            if (this.gameObject.player.HP > 50)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine("Y̸̢̨͉͖̣̖̼̜̟̱̞̫̌ͅò̷̢̺̯̠͓̦̫̣̋̀̄̉̀̔͊̕̕ͅų̸̨̨͎͔̽͝'̸̧̤͓̝̻͖̬̗͖̩̗̩͚̣͑̌̔̒͋͌̾̿̎v̴̧̢͚̆̆̈́͛͠ę̷͌͊͗͐͠ ̴̹͔̯͇͒̇s̶͖͓̲̱̼̙̲̪̼̔͐͜é̸͙̳̜͎̈́͛̒͜ͅẹ̷̺̺͓̹̱̟̘̹͚̺̉̃̓̈́͛͂̌̚ṋ̴̑̂́͜ ̸̧̤̣͕̘̫͚͆͗͒̉́̀ḇ̷̨̞̦̥̯̯͙̖͕͍̲̩͌͘͜͝ȩ̴̨̼̥̩̩̪͎̺͎̤͛́̓̈́̈́̎͊́̍̀̚͘͜͝t̸̹͙̖͎̘̓t̴̺͌̌͐̚ë̵̖̺̘́̊̉͗̍r̷͉͔̪̈́́̇̉̈́̉̌̊̄͐̒̒͘ ̴̡̠̞̪̩̮̻̗̋̀̊̈́͂̈́͒͛̋̍͌̚̕̕d̷̙̰͔̘͇̄͌͌͠ȃ̶̡̢̛̱͖̦̘̫̭͙̟̠̫̭͓̀̀̄̎̃͊͂͛̎̂̈́̕͝y̵̬̹͍͉̼͓̦̗̱̤̙̠̰̟̙̒́͂̎͗̓̔̾̑͊̓̈́ṡ̵̢̳͍̳͍͙͓̆̕͜͜ͅ");

            Console.ForegroundColor = ConsoleColor.Gray;


        }
    }
}
