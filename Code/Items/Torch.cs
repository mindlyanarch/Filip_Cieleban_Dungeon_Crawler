using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Torch : GameItems, ISetsLight
    {
        public Torch()
        {
        }

        virtual public List<string> SetLight(Player player)
        {
            List<string> light = new();

            light.Add("It's cold in here...");
            return light; }
    }


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
    public class PuzzleTorch : Torch
    {
        public PuzzleTorch()

        {

            Name = "Torch of Aphelionbral";
            Description = "In the golden yellow light of Aphelionbral, close things, aren't. Far things, aren't.";
        }
        public List<string> SetLight(Player player)
        {
            List<string> light = new();

            light.Add("You can barely tell where you're standing in the room.");
            light.Add(player.currentRoom.Name);
            light.Add(player.currentRoom.Description);

            return light;
        }

    }
        
}
