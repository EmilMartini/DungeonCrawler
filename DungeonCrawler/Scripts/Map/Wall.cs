using System;
namespace DungeonCrawler
{
    class Wall : Tile
    {
        public Wall(bool explored)
        {
            Graphic = "#";
            IsExplored = explored;
            Color = ConsoleColor.DarkRed;
        }
    }
}
