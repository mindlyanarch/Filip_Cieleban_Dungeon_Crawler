using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{

        public abstract class Creature : IDamageable
        {
            public int MAXHP { get; protected set; }
            public int HP { get; protected set; }
            public int Damage { get; protected set; }
            public int ID { get; protected set; }
            public string Name { get; protected set; }
            public string Description { get; protected set; }


            public Room currentRoom { get; protected set; }

            public Creature(Room location)
            {
                Name = "Creature";
                Description = "This shouldn't exist.";
                this.currentRoom = location;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public Room GetRoom() { return this.currentRoom; }

            public void Attack()
            {
                
            
            }
            public void TakeDamage(int damage) {HP -= damage;}



        }

        interface IDamageable
        {

            public void Attack();
            public void TakeDamage(int Damage);
      

        }
        internal class Rat : Creature
        {
            public Rat(Room location) : base(location) 
            {
                Name = "Rat";
                Description = "A mangy rat. It will not attack unless provoked";
                MAXHP = 5;
                HP = 5;
                Damage = 5;


                
            }
            public void Turn()
            {
                Console.WriteLine("The rat chitters away idly.");
            }
        }

}
