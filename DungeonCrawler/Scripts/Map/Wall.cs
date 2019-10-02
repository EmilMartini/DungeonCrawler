using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    class Wall : Tile
    {
        public Wall(bool explored)
        {
            this.Graphic = "#";
            this.IsExplored = explored;
            this.Color = ConsoleColor.DarkRed;
        }
    }
}
