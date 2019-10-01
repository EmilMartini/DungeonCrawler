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
            foreach (GameObject gameObject in stateMachine.Levels[(int)stateMachine.CurrentLevel].ActiveGameObjects)
            {
                if(!gameObject.GetType().Equals(typeof(Enemy)))
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
                        gameObject.Position = targetEnemyPosition;
                    }
                }
            }
        }
        public void ResetEnemyPositions()
        {
            if(stateMachine.PreviousEnemyPositions != null)
            {
                for (int i = 0; i < stateMachine.Levels[(int)stateMachine.CurrentLevel].Enemies.Length; i++)
                {
                    stateMachine.PreviousEnemyPositions[i] = new Point(0,0);
                }
            }
        }
        private bool PathAvailable(Point targetEnemyPosition)
        {
            var activeGameObjects = stateMachine.Levels[(int)stateMachine.CurrentLevel].ActiveGameObjects;
            for (int i = 0; i < activeGameObjects.Count; i++)
            {
                if (activeGameObjects[i].Position.Equals(targetEnemyPosition))
                {
                    return false;
                }
            }
            if(stateMachine.Levels[(int)stateMachine.CurrentLevel].InitialLayout[stateMachine.TargetEnemyPosition.row, stateMachine.TargetEnemyPosition.column].GetType().Equals(typeof(Door)) ||
               stateMachine.Levels[(int)stateMachine.CurrentLevel].InitialLayout[stateMachine.TargetEnemyPosition.row, stateMachine.TargetEnemyPosition.column].GetType().Equals(typeof(Wall)))
            {
                return false;
            }
            return true;
        }
        public Point TargetEnemyPosition { get => targetEnemyPosition; set => targetEnemyPosition = value; }
        public Point CurrentEnemyPosition { get => currentEnemyPosition; set => currentEnemyPosition = value; }
    }
}