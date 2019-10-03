using System.Collections.Generic;
namespace DungeonCrawler
{
    public class Level
    {
        private Tile[,] layout;
        private List<GameObject> activeGameObjects;
        private Point[] previousEnemyPositions;
        private Point playerStartingTile;
        private int numberOfEnemies;
        private Point playerPositionWhenExit;
        public Level(Tile[,] layout,List<GameObject> gameObjects, Point playerStartingTile, int numberOfEnemies)
        {
            activeGameObjects = gameObjects;
            this.layout = layout;
            PlayerStartingTile = playerStartingTile;
            NumberOfEnemies = numberOfEnemies;
            PlayerExitPosition = PlayerStartingTile;
            activeGameObjects = new List<GameObject>();
            previousEnemyPositions = new Point[NumberOfEnemies];
        }
        public Tile[,] Layout
        {
            get { return layout; }
            set { layout = value; }
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
        public Point PlayerExitPosition
        {
            get { return playerPositionWhenExit; }
            set { playerPositionWhenExit = value; }
        }
        public List<GameObject> ActiveGameObjects
        {
            get { return activeGameObjects; }
            set { activeGameObjects = value; }
        }
    }
}
