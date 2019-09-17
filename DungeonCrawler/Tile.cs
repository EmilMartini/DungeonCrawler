using System;

namespace DungeonCrawler
{
    public abstract class Tile
    {
        public TileType TileType { get; protected set; }
        public string Symbol { get; protected set; }
        public Point Point { get; protected set; }
    }
}