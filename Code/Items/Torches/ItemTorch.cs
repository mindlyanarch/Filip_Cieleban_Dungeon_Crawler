using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Items.Torches
{
    public class ItemTorch : Torch
    {
        public ItemTorch()

        {

            Name = "Torch of Stipple";
            Description = "Things glint in the shadows of the clean blue light of Stipple.";

        }
        public override List<string> SetLight(Player player)
        {
            List<string> light = new();

            light.Add("The flame of the torch radiates no heat.");
            light.Add(player.currentRoom.Name);
            light.Add(player.currentRoom.Description);
            light.Add("Monster health should have gone here");
            return light;
        }
    }
}
