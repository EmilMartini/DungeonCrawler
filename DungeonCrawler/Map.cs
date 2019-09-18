using System;


namespace DungeonCrawler
{
    public class Map
    {
        public Tile[,] ExploredLayout;
        public Tile[,] InitialLayout;
        public Size Size;

        public Map(Size size)
        {
            Size = size;
        }
    }
}
