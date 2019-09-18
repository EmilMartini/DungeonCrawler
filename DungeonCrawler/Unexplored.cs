using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    class Unexplored : Tile
    {

        public Unexplored()
        {
            this.TileType = TileType.Unexplored;
            this.Graphic = " ";
        }

    }
}
