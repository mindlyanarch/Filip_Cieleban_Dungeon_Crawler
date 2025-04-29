using DungeonExplorer.Code.Map.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Creatures
{
    internal class RatDire : Enemy
    {
        new int difficulty = 2;
        new string Name = "Dire Rat";
        new string Description = "Rodents of Unusual Size? Yes, they exist.";
        new bool Hostile = true;

        public RatDire()
        {
            MAXHP = 15;
            HP = MAXHP;
            Damage = 10;

        }
        public RatDire(Room location) : base(location)
        {

            MAXHP = 10;
            HP = MAXHP;
            Damage = 10;

        }
        public override void Turn(Player target)
        {
           target.TakeDamage(Damage);
            Console.WriteLine($"The {Name} bites you!");
        }

    }
}
