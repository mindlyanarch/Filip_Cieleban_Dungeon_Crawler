using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class GameItems
    {
        public string Name { get;  protected set; }
        public string Description { get; protected set; }

        public string Type { get; protected set; }

    public GameItems()
        { 
           
        }
    }

    interface ISetsLight
    {  List<string> SetLight(Player player); }

    interface IUsable { void Use(); }


}
