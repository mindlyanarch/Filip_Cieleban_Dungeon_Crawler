using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Unique
    {
        public class Rock
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Weight { get; set; }
            public int Value { get; set; }
            public Rock()
            {
                Name = "Rock";
                Description = "Engravings offer no tactical advantage whatsoever.";
                Weight = 1;
                Value = 0;
            }
        }

    }
}
