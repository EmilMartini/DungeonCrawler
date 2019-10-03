using System;
namespace DungeonCrawler
{
    public class EnemyController
    {
        private Random random = new Random();
        private GameplayManager gameplayManager;
        private Point currentEnemyPosition;
        private Point targetEnemyPosition;
        public EnemyController(GameplayManager gameplayManager)
        {
            this.gameplayManager = gameplayManager;
        }
        public void MoveEnemies()
        {
            int index = 0;
            Level currentLevel = gameplayManager.Levels[(int)gameplayManager.CurrentLevel];
            foreach (GameObject gameObject in currentLevel.ActiveGameObjects)
            {
                if(!(gameObject is Enemy))
                {
                    continue;
                } else 
                {
                    int row = 0, column = 0;
                    while (row == 0 && column == 0)
                    {
                        row = random.Next(-1, 2);
                        column = random.Next(-1, 2);
                    }
                    targetEnemyPosition = new Point(gameObject.Position.row + row, gameObject.Position.column + column);
                    if(PathAvailable(targetEnemyPosition, currentLevel))
                    {
                        currentLevel.PreviousEnemyPositions[index] = new Point(gameObject.Position.row, gameObject.Position.column);
                        gameObject.Position = targetEnemyPosition;
                        index++;
                    }
                }
            }
        }
        private bool PathAvailable(Point targetEnemyPosition, Level currentLevel)
        {
            var activeGameObjects = currentLevel.ActiveGameObjects;
            var targetTile = currentLevel.Layout[targetEnemyPosition.row, targetEnemyPosition.column];
            for (int i = 0; i < activeGameObjects.Count; i++)
            {
                if(activeGameObjects[i] is Enemy)
                {
                    continue;
                } else
                {
                    if (activeGameObjects[i].Position.Equals(targetEnemyPosition))
                    {
                        return false;
                    }
                }
            }
            if (targetTile is Door || targetTile is Wall)
            {
                return false;
            }
            return true;
        }
        public Point TargetEnemyPosition { get => targetEnemyPosition; set => targetEnemyPosition = value; }    //FIxa enkapsuleringen
        public Point CurrentEnemyPosition { get => currentEnemyPosition; set => currentEnemyPosition = value; } //FIxa enkapsuleringen
    }
}