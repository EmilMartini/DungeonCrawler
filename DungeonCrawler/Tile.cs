using System;

namespace DungeonCrawler
{
    public class Tile
    {
        public TileType TileType;

        public uint TileHorizontal;
        public uint TileVertical;
        public string Symbol;

        public Tile(TileType assignedTileType, uint vertical, uint horizontal, string symbol = "")
        {
            TileType = assignedTileType;
            TileVertical = vertical;
            TileHorizontal = horizontal;
            Symbol = symbol;
        }
    }
}