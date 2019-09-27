using System;

namespace DungeonCrawler
{
    class EnemyController
    {
        private Random random = new Random();
        private Point currentEnemyPosition;
        private Point nextEnemyPosition;
        private readonly Level[] levels;
        private readonly LevelRenderer levelRenderer;

        public EnemyController(Level[] levels, LevelRenderer mapRenderer)
        {
            this.levels = levels ?? throw new ArgumentNullException(nameof(levels));
            this.levelRenderer = mapRenderer ?? throw new ArgumentNullException(nameof(mapRenderer));
        }

        public Point CurrentEnemyPosition
        {
            get { return currentEnemyPosition; }
            set { currentEnemyPosition = value; }
        }
        public Point NextEnemyPosition
        {
            get { return nextEnemyPosition; }
            set { nextEnemyPosition = value; }
        }
        public void Move()
        {
            for (int i = 0; i < levels[(int)LevelLoader.CurrentLevel].Enemies.Length; i++)
            {
                int row = 0, column = 0;
                while (row == 0 && column == 0)
                {
                    row = random.Next(-1, 2);
                    column = random.Next(-1, 2);
                }
                currentEnemyPosition = new Point(levels[(int)LevelLoader.CurrentLevel].Enemies[i].Position.row, levels[(int)LevelLoader.CurrentLevel].Enemies[i].Position.column);
                nextEnemyPosition = new Point(currentEnemyPosition.row + row, currentEnemyPosition.column + column);

                if (levels[(int)LevelLoader.CurrentLevel].InitialLayout[nextEnemyPosition.row, nextEnemyPosition.column].TileType == TileType.Wall ||
                    levels[(int)LevelLoader.CurrentLevel].InitialLayout[nextEnemyPosition.row, nextEnemyPosition.column].TileType == TileType.Door ||
                    levels[(int)LevelLoader.CurrentLevel].InitialLayout[nextEnemyPosition.row, nextEnemyPosition.column].TileType == TileType.Key)
                {
                    continue;
                } else
                {
                    if (levels[(int)LevelLoader.CurrentLevel].ExploredLayout[nextEnemyPosition.row, nextEnemyPosition.column].IsExplored == true)
                    {
                        levels[(int)LevelLoader.CurrentLevel].Enemies[i].IsExplored = true;
                    } else
                    {
                        levels[(int)LevelLoader.CurrentLevel].Enemies[i].IsExplored = false;
                    }
                    UpdateEnemyPositions(levels[(int)LevelLoader.CurrentLevel].Enemies[i], nextEnemyPosition, currentEnemyPosition, i);
                }
            }     
        }
        public void UpdateEnemyPositions(Enemy enemy, Point targetPosition, Point currentEnemyPosition, int index)
        {
            levels[(int)LevelLoader.CurrentLevel].PreviousEnemyPositions[index] = currentEnemyPosition;
            levels[(int)LevelLoader.CurrentLevel].ExploredLayout[enemy.Position.row, enemy.Position.column] = levels[(int)LevelLoader.CurrentLevel].InitialLayout[enemy.Position.row, enemy.Position.column];
            enemy.Position = targetPosition;
            levels[(int)LevelLoader.CurrentLevel].ExploredLayout[enemy.Position.row, enemy.Position.column] = enemy;
        }

    }
}