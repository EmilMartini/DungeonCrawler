using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Floor : Tile
    {
        public Floor(int x, int y)
        {
            this.TileType = TileType.Floor;
            this.Graphic = "-";
            this.Point = new Point(x, y);
        }
    }
}
