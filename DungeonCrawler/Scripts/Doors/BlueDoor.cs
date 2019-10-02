using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Doors
{
    public class BlueDoor : Door
    {
        public BlueDoor()
        {
            this.Unlock = Unlock.Blue;
            this.IsExplored = false;
            this.Color = ConsoleColor.DarkBlue;
            this.Graphic = "D";    
        }
    }
}
