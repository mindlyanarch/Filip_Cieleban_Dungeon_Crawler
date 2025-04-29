using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Code.Items.Torches
{
    public abstract class Torch : GameItems, ISetsLight
    {
        public Torch()
        {
        }

        virtual public List<string> SetLight(Player player)
        {
            List<string> light = new();

            light.Add("It's cold in here...");
            return light;
        }
    }


   

  

    

}
