using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
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

            List<string> info = SetTorchLevel();
        }

        public List<string> Update(Game game)
        {

            List<string> info = SetTorchLevel();

            return info;

        }

        public List<string> SetTorchLevel()
        {
            /*Torch level 0 should display nothing
            * level 1 should display room name and description, and enemies
            * level 2 should display items
            * level 3 should display enemies hp
            * level 4 should display nothing
            */
            int TorchLevel = gameObject.player.EquippedTorch.SetLight(gameObject.player);

            info = new();

            switch (torchLevel)
            {
                case 0: { info.Add("It's cold in here..."); break; }
                case 1: {
                        info.Add("The warmth from the torch is cozy.");
                        info.Add(gameObject.player.currentRoom.Name);
                        info.Add(gameObject.player.currentRoom.Description);
                        break; 
                        }
                case 2: {
                        info.Add("The ")

            }

            return info;
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
