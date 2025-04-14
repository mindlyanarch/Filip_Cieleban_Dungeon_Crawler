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

    }

        interface IEnemyAI

        { public void Turn(); }
        interface IDamageable
        {

            public void Attack();
            public void TakeDamage(int Damage);
      

        }
        internal class Rat : Enemy, IEnemyAI
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
