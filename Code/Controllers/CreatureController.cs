using DungeonExplorer.Code.Creatures.Enemies;
using DungeonExplorer.Code.Map.Rooms;
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

        /// <summary>
        /// Remove the specified enemy from target room and from the master list
        /// </summary>
        /// <param name="target"></param>
        /// <param name="room"></param>
        public void Kill(Enemy target, Room room)
        {
            room.Enemies.Remove(target);
            Master_List_Creatures.Remove(target);
        }

        /// <summary>
        /// Gets the list of active enemies from the player's current room
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public List<Enemy> GetEnemies(Room room)
        {


            if (Master_List_Creatures.Count != 0)
            {
                this.Master_List_Creatures = new();
            }
            foreach (Enemy enemy in room.Enemies)
            {
                Master_List_Creatures.Add(enemy);

            }
            return Master_List_Creatures;
        }

        /// <summary>
        /// Each enemy in the room takes an action
        /// </summary>
        /// <param name="player"></param>

        public void EnemyTurn(Player player)
        {
            foreach (var enemy in this.Master_List_Creatures)

            {
                enemy.Turn(player);
            }

        }
        /// <summary>
        /// spawns enemies in the current floor up to the floor's difficulty
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
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
                    var room = floor.Values.ElementAt(select);
                    room.Enemies.Add(enemy);
                    enemy.SetRoom(null);
                }
            }
            return Creatures;
        }
    }
}
