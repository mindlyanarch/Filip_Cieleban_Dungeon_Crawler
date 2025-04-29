using DungeonExplorer.Code.Map.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Creatures.Enemies
{
    internal class Rat : Enemy
    {


        public Rat()
        {
            Name = "Rat";
            Description = "A mangy rat. It will not attack unless provoked";
            MAXHP = 10;
            HP = MAXHP;
            Damage = 5;
            Hostile = false;


        }
        public Rat(Room location) : base(location)
        {
            Name = "Rat";
            Description = "A mangy rat. It will not attack unless provoked";
            MAXHP = 10;
            HP = MAXHP;
            Damage = 5;
            Hostile = false;


        }
        public override void Turn()
        {
            if (!Hostile)
            { Console.WriteLine("The rat chitters away idly."); }

            else

            {
                //  Player target = currentRoom
                //  player.TakeDamage(Damage);
            }
        }

    }
}
