using System;

namespace DungeonCrawler
{
    public abstract class Tile
    {
        public TileType TileType { get; set; }
        public string Render { get; set; }
        public Point Point { get; set; }
    }
}