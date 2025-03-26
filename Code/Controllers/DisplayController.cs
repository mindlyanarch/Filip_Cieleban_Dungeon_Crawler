using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class DisplayController()
    {

        public List<string> info { get; private set; }

        public int torchLevel { get; private set; }

        private Game gameObject { get; set; }


        public DisplayController(Game game) : this()

        {
            gameObject = game;

            info = new();
            info.Add(SetTorchLevel());
            info.Add(game.player.currentRoom.Description);
            info.Add(game.player.currentRoom.Description);
        }

        public List<string> Update(Game game)
        {
            int TorchLevel = gameObject.player.EquippedTorch.TorchLevel;


            info[0] = SetTorchLevel();
            info[1] = game.player.currentRoom.Description;
            info[2] = game.player.currentRoom.Description;

            return info;

        }


        }
        public void Display_Main(Command command)
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
