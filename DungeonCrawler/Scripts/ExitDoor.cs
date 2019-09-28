using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class ExitDoor : Door
    {
        public ExitDoor()
        {
            this.Unlock = Unlock.Skeleton;
            this.TileType = TileType.Door;
            this.IsExplored = false;
            this.Graphic = "D";
            this.Color = ConsoleColor.DarkGreen;
        }
    }
}
