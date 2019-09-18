namespace DungeonCrawler
{
    public class Map
    {
        public Map(Size size)
        {
            Size = size;
        }
        public Tile[,] ExploredLayout;
        public Tile[,] InitialLayout;
        public Size Size;
    }
}
