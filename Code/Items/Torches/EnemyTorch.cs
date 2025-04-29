using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Items.Torches
{
    public class EnemyTorch : Torch
    {
        public EnemyTorch()

        {

            Name = "Torch of Carnacht";
            Description = "The blood red light of Carnacht exposes weakness.";
        }
        public override List<string> SetLight(Player player)
        {
            List<string> light = new();

            light.Add("You can barely stand the heat from your torch.");
            light.Add(player.currentRoom.Name);
            light.Add(player.currentRoom.Description);
            light.Add("Monster health should have gone here");
            return light;

        }
    }
}
