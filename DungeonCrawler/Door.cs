using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    class Door : Tile
    {
        public Door()
        {
            this.TileType = TileType.Door;
            this.Graphic = "D";
            this.IsExplored = false;
            this.Color = ConsoleColor.DarkMagenta;
        }
    }
}
