using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Torch : GameItems
    {
        /* Types of darkness:
         * dungeon dark: shows nothing
         * 
         * carnacht: display enemy HP
         * terpsifulgin: displays loot on ground
         * nefarshade: obscures distances.
         */


        public int TorchLevel {  get; protected set; }


        public Torch()
        {
        }

    }


    public class DefaultTorch : Torch
    {
        public DefaultTorch()

        {
            TorchLevel = 1;
            Name = "Torch";
            Description = "An otherwise unremarkable torch. It lets you see your obvious surroundings";
        }
    }

    public class EnemyTorch : Torch
    {
        public EnemyTorch()

        {
            TorchLevel = 2;
            Name = "Torch of Carnacht";
            Description = "The blood-red light of Carnacht exposes weakness.";
        }
    }

    public class ItemTorch : Torch
    {
        public ItemTorch()

        {
            TorchLevel = 3;
            Name = "Torch of Stipple";
            Description = "Things glint in the shadows of the clean-blue light of Stipple.";
        }
    }
    public class PuzzleTorch : Torch
    {
        public PuzzleTorch()

        {
            TorchLevel = 4;
            Name = "Torch of Aphelionbral";
            Description = "In the light of Aphelionbral, close things, aren't. Far things, aren't.";
        }
    }
}
