using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class EnemyController
    {
        List<Enemy> creatures;
        public EnemyController()
        {
            creatures = new();
        }


        public List<Enemy> GetEnemies(Player player)
        {


            if (creatures.Count != 0)
            {
                this.creatures = new();
            }
            foreach (Enemy enemy in player.currentRoom.Enemies)
            {
                creatures.Add(enemy);

            }
            return creatures;
        }
        public void EnemyTurn()
        {
            foreach (var enemy in this.creatures)

            {
                enemy.Turn();
            }

        }
    }
}
