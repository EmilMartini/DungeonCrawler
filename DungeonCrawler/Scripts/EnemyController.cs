using System;

namespace DungeonCrawler
{
    public class EnemyController
    {
        private Random random = new Random();
        private StateMachine stateMachine;
        private Point currentEnemyPosition;
        private Point targetEnemyPosition;


        public EnemyController(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        public void Move()
        {
            int index = 0;
            foreach (GameObject gameObject in stateMachine.Levels[(int)stateMachine.CurrentLevel].ActiveGameObjects)
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
                        stateMachine.Levels[(int)stateMachine.CurrentLevel].PreviousEnemyPositions[index] = new Point(gameObject.Position.row, gameObject.Position.column);
                        gameObject.Position = targetEnemyPosition;
                        index++;
                    }
                }
            }
        }
        public void ResetEnemyPositions()
        {
            if(stateMachine.Levels[(int)stateMachine.CurrentLevel].PreviousEnemyPositions != null)
            {
                for (int i = 0; i < stateMachine.Levels[(int)stateMachine.CurrentLevel].NumberOfEnemies; i++)
                {
                    stateMachine.Levels[(int)stateMachine.CurrentLevel].PreviousEnemyPositions[i] = new Point(0,0);
                }
            }
        }
        private bool PathAvailable(Point targetEnemyPosition)
        {
            var activeGameObjects = stateMachine.Levels[(int)stateMachine.CurrentLevel].ActiveGameObjects;
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
            if(stateMachine.Levels[(int)stateMachine.CurrentLevel].ExploredLayout[targetEnemyPosition.row, targetEnemyPosition.column] is Door ||
               stateMachine.Levels[(int)stateMachine.CurrentLevel].ExploredLayout[targetEnemyPosition.row, targetEnemyPosition.column] is Wall)
            {
                return false;
            }
            return true;
        }
        public Point TargetEnemyPosition { get => targetEnemyPosition; set => targetEnemyPosition = value; }
        public Point CurrentEnemyPosition { get => currentEnemyPosition; set => currentEnemyPosition = value; }
    }
}