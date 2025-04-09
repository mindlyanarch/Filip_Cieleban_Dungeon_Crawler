using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{

    internal class Cardinality
    {
        public Dictionary<string, int> Cardinals { get; private set; }

        public Cardinality()
        {

            Cardinals = new();
            Cardinals.Add("North", 0);
            Cardinals.Add("East", 1);
            Cardinals.Add("South", 2);
            Cardinals.Add("West", 3);
        }

        public static int GetOppositeDirection(int direction)
        {

            switch (direction)

            {
                case 0: { return 2; }
                case 1: { return 3; }
                case 2: { return 0; }
                case 3: { return 1; }
                default: { throw new ArgumentOutOfRangeException(); }

            }
        }

        public string GetCardinalString(int direction)

        {
            foreach (var card in Cardinals)
            {
                if (card.Value == direction)
                    return card.Key;
            }
            return default;
        }
    }
}
