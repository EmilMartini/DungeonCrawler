namespace DungeonCrawler
{
    public class Level
    {
        public Level(Size size, Point playerStartingTile)
        {
            Size = size;
            PlayerStartingTile = playerStartingTile;
        }
        public Tile[,] ExploredLayout;
        public Tile[,] InitialLayout;
        public Enemy[] Enemies;
        public Point[] PreviusEnemyPositions;
        public Size Size;
        public Point PlayerStartingTile;
    }
}
