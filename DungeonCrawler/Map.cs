using System;


namespace DungeonCrawler
{
    public class Map
    {
        public Tile[,] RenderedLayout;
        public Tile[,] InitialLayout;
        public Size Size;

        public Map(Size size)
        {
            Size = size;
        }
    }
}
