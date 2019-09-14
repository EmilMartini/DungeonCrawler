using System;

namespace DungeonCrawler
{
    internal class Tile
    {
        public enum TileType { Floor, Key, Door}
        public TileType tileType;

        public int TileHorizontal;
        public int TileVertical;

        public string Display;

        public Tile(TileType assignedTileType, int horizontal, int vertical, string display)
        {
            tileType = assignedTileType;
            TileHorizontal = horizontal;
            TileVertical = vertical;
            Display = display;
        }

    }
}