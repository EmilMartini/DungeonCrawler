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
            for (int i = 0; i < gameplayManager.Levels.Length; i++)
            {
                levels[i].Layout = new Tile[levels[i].Size.Height, levels[i].Size.Width];

                for (int row = 0; row < levels[i].Size.Height; row++)
                {
                    for (int column = 0; column < levels[i].Size.Width; column++)
                    {
                        if (column == 0 || column == levels[i].Size.Width - 1 || row == 0 || row == levels[i].Size.Height - 1)
                        {
                            levels[i].Layout[row, column] = new Wall(true);
                        }
                        else
                        {
                            levels[i].Layout[row, column] = new Floor();
                        }
                    }
                }

                //Spawn enemies
                for (int enemyIndex = 0; enemyIndex < levels[i].NumberOfEnemies; enemyIndex++)
                {
                    int enemySpawnPositionRow, enemySpawnPositionColumn;
                    enemySpawnPositionRow = rnd.Next(1, levels[i].Layout.GetLength(0) - 2);
                    enemySpawnPositionColumn = rnd.Next(1, levels[i].Layout.GetLength(1) - 2);

                    levels[i].ActiveGameObjects.Add(new Enemy(enemySpawnPositionRow, enemySpawnPositionColumn));
                }
            }
            levelLayout.SetLevelOneLayout();
            levelLayout.SetLevelTwoLayout();
            levelLayout.SetLevelThreeLayout();
        }
    }
}
