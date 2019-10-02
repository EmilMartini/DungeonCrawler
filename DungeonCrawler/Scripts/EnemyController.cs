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
        public void Move()  //Kanske  någon kommentar inuti, får se
        {
            int index = 0;
            foreach (GameObject gameObject in gameplayManager.Levels[(int)gameplayManager.CurrentLevel].ActiveGameObjects)
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
                    if(PathAvailable(targetEnemyPosition))
                    {
                        gameplayManager.Levels[(int)gameplayManager.CurrentLevel].PreviousEnemyPositions[index] = new Point(gameObject.Position.row, gameObject.Position.column);
                        gameObject.Position = targetEnemyPosition;
                        index++;
                    }
                }
            }
        }
        public void ResetEnemyPositions()
        {
            if(gameplayManager.Levels[(int)gameplayManager.CurrentLevel].PreviousEnemyPositions != null)
            {
                for (int i = 0; i < gameplayManager.Levels[(int)gameplayManager.CurrentLevel].NumberOfEnemies; i++)
                {
                    gameplayManager.Levels[(int)gameplayManager.CurrentLevel].PreviousEnemyPositions[i] = new Point(0,0);
                }
            }
        }
        private bool PathAvailable(Point targetEnemyPosition)
        {
            var activeGameObjects = gameplayManager.Levels[(int)gameplayManager.CurrentLevel].ActiveGameObjects;
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
            if(gameplayManager.Levels[(int)gameplayManager.CurrentLevel].ExploredLayout[targetEnemyPosition.row, targetEnemyPosition.column] is Door ||
               gameplayManager.Levels[(int)gameplayManager.CurrentLevel].ExploredLayout[targetEnemyPosition.row, targetEnemyPosition.column] is Wall)
            {
                return false;
            }
            return true;
        }
        public Point TargetEnemyPosition { get => targetEnemyPosition; set => targetEnemyPosition = value; }    //FIxa enkapsuleringen
        public Point CurrentEnemyPosition { get => currentEnemyPosition; set => currentEnemyPosition = value; } //FIxa enkapsuleringen
    }
}