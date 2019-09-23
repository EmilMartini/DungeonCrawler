using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Doors
{
    public class YellowDoor : Door
    {
        public YellowDoor()
        {
            this.Unlock = Unlock.Yellow;
            this.TileType = TileType.Door;
            this.IsExplored = false;
            this.Color = ConsoleColor.DarkYellow;
            this.Graphic = "D";
        }
    }
}
