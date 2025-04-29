using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Sword : GameItems, IUsable
    {
        private int Damage { get; set; }
        public int damage { get { return Damage; } }

        public bool Equippable = true;

        public Sword(string name, string description, int damage)
        {
            Name = name;
            Description = description;
            Type = "Sword";

            Damage = damage;

        }

        public void Use()
        { }
    }
}
