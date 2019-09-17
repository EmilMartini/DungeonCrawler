using System;


namespace DungeonCrawler
{
    public class Map
    {
        public Tile[,] Tiles;
        public Size Size;

        public Map(Size size)
        {
            Size = size;
        }
    }
}
