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
        private Point entryDoor;
        private Point exitDoor;
        public Level(Tile[,] layout,List<GameObject> gameObjects, Point playerStartingTile, int numberOfEnemies, Point EntryDoor, Point ExitDoor)
        {
            this.activeGameObjects = gameObjects;
            this.layout = layout;
            this.PlayerStartingTile = playerStartingTile;
            this.NumberOfEnemies = numberOfEnemies;
            this.PlayerExitPosition = PlayerStartingTile;
            this.previousEnemyPositions = new Point[NumberOfEnemies];
            this.entryDoor = EntryDoor;
            this.exitDoor = ExitDoor;
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

        public Point EntryDoor { get => entryDoor; set => entryDoor = value; }
        public Point ExitDoor { get => exitDoor; set => exitDoor = value; }
    }
}
