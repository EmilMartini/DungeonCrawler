using System;

namespace DungeonCrawler
{
    public class EnemyController
    {
        private Random random = new Random();
        private StateMachine stateMachine;

        public EnemyController(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        public void Move()
        {
            for (int i = 0; i < stateMachine.Levels[(int)stateMachine.LevelIndex].Enemies.Length; i++)
            {
                int row = 0, column = 0;
                while (row == 0 && column == 0)
                {
                    row = random.Next(-1, 2);
                    column = random.Next(-1, 2);
                }
                stateMachine.CurrentEnemyPosition = new Point(stateMachine.Levels[(int)stateMachine.LevelIndex].Enemies[i].Position.row, stateMachine.Levels[(int)stateMachine.LevelIndex].Enemies[i].Position.column);
                stateMachine.TargetEnemyPosition = new Point(stateMachine.CurrentEnemyPosition.row + row, stateMachine.CurrentEnemyPosition.column + column);

                if (stateMachine.Levels[(int)stateMachine.LevelIndex].InitialLayout[stateMachine.TargetEnemyPosition.row, stateMachine.TargetEnemyPosition.column].TileType == TileType.Wall ||
                    stateMachine.Levels[(int)stateMachine.LevelIndex].InitialLayout[stateMachine.TargetEnemyPosition.row, stateMachine.TargetEnemyPosition.column].TileType == TileType.Door ||
                    stateMachine.Levels[(int)stateMachine.LevelIndex].InitialLayout[stateMachine.TargetEnemyPosition.row, stateMachine.TargetEnemyPosition.column].TileType == TileType.Key)
                {
                    continue;
                } else
                {
                    if (stateMachine.Levels[(int)stateMachine.LevelIndex].ExploredLayout[stateMachine.TargetEnemyPosition.row, stateMachine.TargetEnemyPosition.column].IsExplored == true)
                    {
                        stateMachine.Levels[(int)stateMachine.LevelIndex].Enemies[i].IsExplored = true;
                    } else
                    {
                        stateMachine.Levels[(int)stateMachine.LevelIndex].Enemies[i].IsExplored = false;
                    }
                    UpdateEnemyPositions(stateMachine.Levels[(int)stateMachine.LevelIndex].Enemies[i], i);
                }
            }     
        }
        public void UpdateEnemyPositions(Enemy enemy, int index)
        {
            stateMachine.Levels[(int)stateMachine.LevelIndex].PreviousEnemyPositions[index] = stateMachine.CurrentEnemyPosition;
            stateMachine.Levels[(int)stateMachine.LevelIndex].ExploredLayout[enemy.Position.row, enemy.Position.column] = stateMachine.Levels[(int)stateMachine.LevelIndex].InitialLayout[enemy.Position.row, enemy.Position.column];
            enemy.Position = stateMachine.TargetEnemyPosition;
            stateMachine.Levels[(int)stateMachine.LevelIndex].ExploredLayout[enemy.Position.row, enemy.Position.column] = enemy;
        }
        public void ResetEnemyPositions()
        {
            if(stateMachine.PreviousEnemyPositions != null)
            {
                for (int i = 0; i < stateMachine.Levels[(int)stateMachine.LevelIndex].Enemies.Length; i++)
                {
                    stateMachine.PreviousEnemyPositions[i] = new Point(0,0);
                }
            }
        }
    }
}