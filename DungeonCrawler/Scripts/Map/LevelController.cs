using System;
namespace DungeonCrawler
{
    public class LevelController
    {
        private GameplayManager gameplayManager;
        private Level[] levels;
        private readonly LevelLayout levelLayout;
        private Random rnd = new Random();
        public LevelController(LevelLayout levelLayout, GameplayManager gameplayManager)
        {
            this.levels = gameplayManager.Levels;
            this.levelLayout = levelLayout;
            this.gameplayManager = gameplayManager;
        }
        public void InitializeLevels()
        {
            for (int levelIndex = 0; levelIndex < gameplayManager.Levels.Length; levelIndex++)
            {
                levels[levelIndex].Layout = new Tile[levels[levelIndex].Size.Height, levels[levelIndex].Size.Width];
                SetOuterWallsAndFloor(levelIndex);
                SpawnEnemies(levelIndex);
            }
            levelLayout.SetLevelOneLayout();
            levelLayout.SetLevelTwoLayout();
            levelLayout.SetLevelThreeLayout();
        }
        void SetOuterWallsAndFloor(int levelIndex)
        {
            for (int row = 0; row < levels[levelIndex].Size.Height; row++)
            {
                for (int column = 0; column < levels[levelIndex].Size.Width; column++)
                {
                    if (column == 0 || column == levels[levelIndex].Size.Width - 1 || row == 0 || row == levels[levelIndex].Size.Height - 1)
                    {
                        levels[levelIndex].Layout[row, column] = new Wall(true);
                    }
                    else
                    {
                        levels[levelIndex].Layout[row, column] = new Floor();
                    }
                }
            }
        }
        void SpawnEnemies(int levelIndex)
        {
            for (int i = 0; i < levels[levelIndex].NumberOfEnemies; i++)
            {
                int enemySpawnPositionRow, enemySpawnPositionColumn;
                enemySpawnPositionRow = rnd.Next(1, levels[levelIndex].Layout.GetLength(0) - 2);
                enemySpawnPositionColumn = rnd.Next(1, levels[levelIndex].Layout.GetLength(1) - 2);
                levels[levelIndex].ActiveGameObjects.Add(new Enemy(enemySpawnPositionRow, enemySpawnPositionColumn));
            }
        }
    }
}

