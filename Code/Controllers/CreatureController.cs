using DungeonExplorer.Code.Creatures;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class CreatureController : Controller
    {
        List<Enemy> Master_List_Creatures { get; set; }
        Dictionary<int, Enemy> SpawnTable { get; set; }

        private Rat rat;
        private RatDire ratDire;
        public CreatureController()
        {
            SpawnTable = new();
                SpawnTable.Add(0, rat = new());
                SpawnTable.Add(1, ratDire = new());

            Master_List_Creatures = new();

        }




        public List<Enemy> GetEnemies(Player player)
        {


            if (Master_List_Creatures.Count != 0)
            {
                this.Master_List_Creatures = new();
            }
            foreach (Enemy enemy in player.currentRoom.Enemies)
            {
                Master_List_Creatures.Add(enemy);

            }
            return Master_List_Creatures;
        }
        public void EnemyTurn(Player player)
        {
            foreach (var enemy in this.Master_List_Creatures)

            {
                enemy.Turn(player);
            }

        }

        public List<Enemy> PopulateFloor(Dictionary<int, Room> floor)
        { 
            List<Enemy> Creatures = new List<Enemy>();
            //Get difficulty of floor.

            int roomDiff = 0;
            foreach (var Room in floor) { roomDiff = roomDiff + Room.Value.roomLevel; }

            //Generate creatures using table

            int creatureDiff = 0;
            Random random = new();
            while (creatureDiff <= roomDiff)

            { 
                int Select = random.Next(this.SpawnTable.Count);

                var enemy = SpawnTable[Select];

                Creatures.Add(enemy);
                this.Master_List_Creatures.Add(enemy);
                creatureDiff = creatureDiff + enemy.difficulty;

            }

            foreach (var enemy in Creatures)
            {
                int select = random.Next(1, floor.Count);
                {
                   floor.ElementAt(select).Value.Enemies.Add(enemy);
                }
            }
            return Creatures;
        }
    }
}
