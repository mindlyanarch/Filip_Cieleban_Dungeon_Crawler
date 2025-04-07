using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Controller
    {
        public List<Controller> ControllerList { get; protected set; }
        public Controller() 
        
        {
            ControllerList = new();
        }

        public List<Controller> Get_Controller_List(List<Controller> list)

        {
            this.ControllerList = list;

            return list;

        }
    }
}
