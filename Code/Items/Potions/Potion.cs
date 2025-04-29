using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Items.Potions
{
    internal class Potion : GameItems, IUsable
    {
        public Potion()
        {
            Name = "Potion";
            Description = "This red liquid restores 25 HP";
            Type = "Potion";
        }

        public void Use() { }
        public void Use(Player player)

        { player.TakeDamage(-25); }
    }
}
