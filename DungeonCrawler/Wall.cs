using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    class Wall : Tile
    {
        public Wall(int x, int y)
        {
            this.TileType = TileType.Wall;
            this.Graphic = "#";
            this.Point = new Point(x, y);
        }

    }
}
