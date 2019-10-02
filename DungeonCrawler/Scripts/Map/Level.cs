using System.Collections.Generic;
namespace DungeonCrawler
{
    public class Level
    {
        private Tile[,] exploredLayout;
        private Tile[,] initialLayout;
        private List<GameObject> activeGameObjects;
        private Enemy[] enemies;
        private Point[] previousEnemyPositions;
        private Size size;
        private Point playerStartingTile;
        private int numberOfEnemies;
        private Point playerPositionWhenExit;
        public Level(Size size, Point playerStartingTile, int numberOfEnemies)
        {
            Size = size;
            PlayerStartingTile = playerStartingTile;
            NumberOfEnemies = numberOfEnemies;
            PlayerPositionWhenExit = PlayerStartingTile;
            activeGameObjects = new List<GameObject>();
            previousEnemyPositions = new Point[NumberOfEnemies];
        }
        public Tile[,] ExploredLayout
        {
            get { return exploredLayout; }
            set { exploredLayout = value; }
        }
        public Tile[,] InitialLayout
        {
            get { return initialLayout; }
            set { initialLayout = value; }
        }
        public Enemy[] Enemies
        {
            get { return enemies; }
            set { enemies = value; }
        }
        public Point[] PreviousEnemyPositions
        {
            get { return previousEnemyPositions; }
            set { previousEnemyPositions = value; }
        }
        public Size Size
        {
            get { return size; }
            set { size = value; }
        }
        public Point PlayerStartingTile
        {
            get { return playerStartingTile; }
            set { playerStartingTile = value; }
        }
        public int NumberOfEnemies
        {
            get { return numberOfEnemies; }
            set { numberOfEnemies = value; }
        }
        public Point PlayerPositionWhenExit { get => playerPositionWhenExit; set => playerPositionWhenExit = value; }   //fixa enkapsulering
        public List<GameObject> ActiveGameObjects { get => activeGameObjects; set => activeGameObjects = value; }       //fixa enkapsulering
    }
}
