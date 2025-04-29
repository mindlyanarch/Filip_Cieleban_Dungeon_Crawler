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

        /// <summary>
        /// Feeds the controller a list of all other controllers.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<Controller> Get_Controller_List(List<Controller> list)

        {
            this.ControllerList = list;

            return list;

        }
    }
}
