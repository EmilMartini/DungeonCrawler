using System;

namespace DungeonCrawler
{
    public abstract class Tile
    {
        private TileType tileType;
        private string graphic;
        private bool isExplored;
        private ConsoleColor color;

        public TileType TileType
        {
            get { return tileType; }
            set { tileType = value; }
        }
        public string Graphic
        {
            get { return graphic; }
            set { graphic = value; }
        }
        public bool IsExplored
        {
            get { return isExplored; }
            set { isExplored = value; }
        }
        public ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}