using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Scripts.Map
{
    class Water : Tile
    {
        public Water()
        {
            this.TileType = TileType.Water;
            this.Graphic = "~";
            this.Color = ConsoleColor.Blue;
        }
    }
}
