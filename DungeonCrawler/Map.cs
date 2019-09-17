using System;


namespace DungeonCrawler
{
    public class Map
    {
        public Tile[,] Tiles;
        public Tile[,] InitialLayout;
        public Size Size;

        public Map(Size size)
        {
            Size = size;
        }
    }
}
