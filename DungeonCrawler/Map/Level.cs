namespace DungeonCrawler
{
    public class Level
    {
        public Tile[,] ExploredLayout;
        public Tile[,] InitialLayout;
        public Enemy[] Enemies;
        public Point[] PreviousEnemyPositions;
        public Size Size;
        public Point PlayerStartingTile;
        private int numberOfEnemies;

        public Level(Size size, Point playerStartingTile, int numberOfEnemies)
        {
            Size = size;
            PlayerStartingTile = playerStartingTile;
            NumberOfEnemies = numberOfEnemies;
        }

        public int NumberOfEnemies
        {
            get { return numberOfEnemies; }
            set { numberOfEnemies = value; }
        }
    }
}
