using System;

namespace DungeonCrawler
{
    public class Tile
    {
        public TileType TileType;

        public int TileHorizontal;
        public int TileVertical;
        public string Display;

        public Tile(TileType assignedTileType, int vertical, int horizontal, string display)
        {
            TileType = assignedTileType;
            TileHorizontal = horizontal;
            TileVertical = vertical;
            Display = display;
        }

    }
}