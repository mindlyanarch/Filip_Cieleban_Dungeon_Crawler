using DungeonExplorer.Code.Map.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Creatures.Enemies
{
    internal class RatDire : Enemy
    {


        public RatDire()
        {
            difficulty = 2;
            MAXHP = 15;
            HP = MAXHP;
            Damage = 10;

            Name = "Dire Rat";
            Description = "Rodents of Unusual Size? Yes, they exist.";
        }
        public RatDire(Room location) : base(location)
        {
            difficulty = 2;
            MAXHP = 10;
            HP = MAXHP;
            Damage = 10;

            Name = "Dire Rat";
            Description = "Rodents of Unusual Size? Yes, they exist.";
        }
        public override void Turn(Player target)
        {
            target.TakeDamage(Damage);
            Console.WriteLine($"The {Name} bites you!");
        }

    }
}
