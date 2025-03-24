using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class GameItems
    {
        public abstract class GameItem
        {   //parent class in advance for part 2 of assignment

            public string Name { get; set; }
            public string Description { get; set; }
            public int ID { get; set; }

        }

        interface Weapon 
        { //interface in advance for part 2 of assignment
          //designates item as equippable
          //used over abstract class because weapons also need to be gameitems and multiple inheritance doesnt exist
          

        }

        public class Sword : GameItem, Weapon
        {
            public Sword()
            {
                Name = "rusty sword";
                Description = "A rusty sword.";
                
            }
        }
    }
}
