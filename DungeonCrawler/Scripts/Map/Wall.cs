using System;
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
