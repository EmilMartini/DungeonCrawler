using System;

namespace DungeonCrawler
{
    public abstract class Tile
    {
        public TileType TileType { get; set; }
        public string Graphic { get; set; }
    }
}