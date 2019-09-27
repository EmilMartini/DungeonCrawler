using System;

namespace DungeonCrawler
{
    class EnemyController
    {
        private Random random = new Random();
        private StateMachine stateMachine;
        private readonly Level[] levels;
        private readonly LevelRenderer levelRenderer;

        public EnemyController(Level[] levels, LevelRenderer mapRenderer, StateMachine stateMachine)
        {
            this.levels = levels ?? throw new ArgumentNullException(nameof(levels));
            this.levelRenderer = mapRenderer ?? throw new ArgumentNullException(nameof(mapRenderer));
            this.stateMachine = stateMachine;
        }
        public void Move()
        {
            for (int i = 0; i < levels[(int)stateMachine.LevelIndex].Enemies.Length; i++)
            {
                int row = 0, column = 0;
                while (row == 0 && column == 0)
                {
                    row = random.Next(-1, 2);
                    column = random.Next(-1, 2);
                }
                stateMachine.CurrentEnemyPosition = new Point(levels[(int)stateMachine.LevelIndex].Enemies[i].Position.row, levels[(int)stateMachine.LevelIndex].Enemies[i].Position.column);
                stateMachine.TargetEnemyPosition = new Point(stateMachine.CurrentEnemyPosition.row + row, stateMachine.CurrentEnemyPosition.column + column);

                if (levels[(int)stateMachine.LevelIndex].InitialLayout[stateMachine.TargetEnemyPosition.row, stateMachine.TargetEnemyPosition.column].TileType == TileType.Wall ||
                    levels[(int)stateMachine.LevelIndex].InitialLayout[stateMachine.TargetEnemyPosition.row, stateMachine.TargetEnemyPosition.column].TileType == TileType.Door ||
                    levels[(int)stateMachine.LevelIndex].InitialLayout[stateMachine.TargetEnemyPosition.row, stateMachine.TargetEnemyPosition.column].TileType == TileType.Key)
                {
                    continue;
                } else
                {
                    if (levels[(int)stateMachine.LevelIndex].ExploredLayout[stateMachine.TargetEnemyPosition.row, stateMachine.TargetEnemyPosition.column].IsExplored == true)
                    {
                        levels[(int)stateMachine.LevelIndex].Enemies[i].IsExplored = true;
                    } else
                    {
                        levels[(int)stateMachine.LevelIndex].Enemies[i].IsExplored = false;
                    }
                    UpdateEnemyPositions(levels[(int)stateMachine.LevelIndex].Enemies[i], i);
                }
            }     
        }
        public void UpdateEnemyPositions(Enemy enemy, int index)
        {
            levels[(int)stateMachine.LevelIndex].PreviousEnemyPositions[index] = stateMachine.CurrentEnemyPosition;
            levels[(int)stateMachine.LevelIndex].ExploredLayout[enemy.Position.row, enemy.Position.column] = levels[(int)stateMachine.LevelIndex].InitialLayout[enemy.Position.row, enemy.Position.column];
            enemy.Position = stateMachine.TargetEnemyPosition;
            levels[(int)stateMachine.LevelIndex].ExploredLayout[enemy.Position.row, enemy.Position.column] = enemy;
        }
    }
}