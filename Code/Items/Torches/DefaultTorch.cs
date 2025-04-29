using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Items.Torches
{
    public class DefaultTorch : Torch
    {
        public DefaultTorch()

        {

            Name = "Torch";
            Description = "An otherwise unremarkable torch. It lets you see your obvious surroundings";
        }
        public override List<string> SetLight(Player player)
        {
            List<string> light = new();

            light.Add("The warmth from the torch is cozy.");
            light.Add(player.currentRoom.Name);
            light.Add(player.currentRoom.Description);

            return light;
        }
    }
}