using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Doors
{
    public class PurpleDoor : Door
    {
        public PurpleDoor()
        {
            this.DoorType = DoorType.Purple;
            this.TileType = TileType.Door;
            this.IsExplored = false;
            this.Color = ConsoleColor.DarkMagenta;
            this.Graphic = "D";
        }
    }
}
