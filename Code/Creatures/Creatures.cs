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
            public bool Hostile { get; protected set; }
            
             public int difficulty { get; protected set; }
            public Room currentRoom { get;  set; }

            public Creature()
            {
                Name = "Creature";
                Description = "This shouldn't exist.";
                difficulty = 1;
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


        public abstract class Enemy : Creature, IEnemyAI
        {
        bool Aggressive = false;

        public Enemy()
        {

        }
        public Enemy(Room location) 
        {
            currentRoom = location;
        }

        public virtual void Turn() { }
        public virtual void Turn(Player target) { }

    }

        interface IEnemyAI

        { public void Turn(); }
        interface IDamageable
        {

            public void Attack();
            public void TakeDamage(int Damage);
      

        }
      

}
