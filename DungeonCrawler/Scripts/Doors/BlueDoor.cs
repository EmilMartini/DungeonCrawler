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
            this.DoorType = DoorType.Blue;
            this.TileType = TileType.Door;
            this.IsExplored = false;
            this.Color = ConsoleColor.DarkBlue;
            this.Graphic = "D";    
        }
    }
}
