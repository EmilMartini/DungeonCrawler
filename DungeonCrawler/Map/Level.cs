namespace DungeonCrawler
{
    public class Level
    {
        public Level(Size size, Point playerStartingTile, int numberOfEnemies)
        {
            Size = size;
            PlayerStartingTile = playerStartingTile;
            NumberOfEnemies = numberOfEnemies;
        }
        public Tile[,] ExploredLayout;
        public Tile[,] InitialLayout;
        public Enemy[] Enemies;
        public Point[] PreviousEnemyPositions;
        public Size Size;
        public Point PlayerStartingTile;
        public int NumberOfEnemies;
    }
}
