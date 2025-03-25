using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DungeonExplorer
{
    internal class Command
    {

       public List<string> playing { get;  set; }
        
        public Command()
        {
            playing = new();

            playing.Add("w. Forward");
            playing.Add("a. Left");
            playing.Add("s. Back");
            playing.Add("d. Right");
            playing.Add("l. Look");
            playing.Add("i. Inventory");
            
        }
    }

   
}
