using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Items.Torches
{
    public class PuzzleTorch : Torch
    {
        public PuzzleTorch()

        {

            Name = "Torch of Aphelionbral";
            Description = "In the golden yellow light of Aphelionbral, close things, aren't. Far things, aren't.";
        }
        public override List<string> SetLight(Player player)
        {
            List<string> light = new();

            light.Add("You can barely tell where you're standing in the room.");
            light.Add(player.currentRoom.Name);
            light.Add(player.currentRoom.Description);

            return light;
        }

    }
}
