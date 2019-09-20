using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Enemy : Tile
    {
        public Point Position;

        public Enemy(int startRow, int startColumn)
        {
            this.TileType = TileType.Monster;
            this.Graphic = "X";
            this.IsExplored = false;
            this.Color = ConsoleColor.Red;
            Position = new Point(startRow, startColumn);
        }
    }
}
