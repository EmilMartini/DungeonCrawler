using System.Collections.Generic;

namespace DungeonCrawler
{
    public class Level
    {
        public Level(Tile[,] layout,List<GameObject> gameObjects, Point playerStartingTile, int numberOfEnemies, Point entryDoor, Point exitDoor)
        {
            ActiveGameObjects = gameObjects;
            Layout = layout;
            PlayerStartingTile = playerStartingTile;
            NumberOfEnemies = numberOfEnemies;
            PlayerExitPosition = PlayerStartingTile;
            PreviousEnemyPositions = new Point[NumberOfEnemies];
            EntryDoor = entryDoor;
            ExitDoor = exitDoor;
        }
        public Tile[,] Layout { get; set; }
        public Point[] PreviousEnemyPositions { get; set; }
        public Point PlayerStartingTile { get; set; }
        public int NumberOfEnemies { get; set; }
        public Point PlayerExitPosition { get; set; }
        public List<GameObject> ActiveGameObjects { get; set; }
        public Point EntryDoor { get; set; }
        public Point ExitDoor { get; set; }
    }
}
