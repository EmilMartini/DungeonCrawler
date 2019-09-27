using System;
using DungeonCrawler.Doors;
using DungeonCrawler.Keys;

namespace DungeonCrawler
{
    class LevelLoader
    {
        private Level[] levels;
        private readonly Player player;
        private readonly LevelLayout levelLayout;
        private static CurrentLevel currentLevel;
        private Random rnd = new Random();

        public LevelLoader(Level[] levels, Player player, LevelLayout levelLayout)
        {
            this.levels = levels;
            this.player = player;
            this.levelLayout = levelLayout;
        }
        public static CurrentLevel CurrentLevel
        {
            get { return currentLevel; }
            set { currentLevel = value; }
        }

        public void SpawnLevelObjects()
        {
            //Spawn enemies
            int enemySpawnPositionRow, enemySpawnPositionColumn;
            for (int i = 0; i < levels[(int)CurrentLevel].Enemies.Length; i++)
            {
                enemySpawnPositionRow = rnd.Next(1, levels[(int)CurrentLevel].InitialLayout.GetLength(0) - 2);
                enemySpawnPositionColumn = rnd.Next(1, levels[(int)CurrentLevel].InitialLayout.GetLength(1) - 2);

                levels[(int)CurrentLevel].Enemies[i] = new Enemy(enemySpawnPositionRow, enemySpawnPositionColumn);
            }

            levels[(int)CurrentLevel].ExploredLayout[player.Position.row, player.Position.column] = player;

            for (int i = 0; i < levels[(int)CurrentLevel].Enemies.Length; i++)
            {
                levels[(int)CurrentLevel].ExploredLayout[levels[(int)CurrentLevel].Enemies[i].Position.row, levels[(int)CurrentLevel].Enemies[i].Position.column] = levels[(int)CurrentLevel].Enemies[i];
            }
            Array.Copy(levels[(int)CurrentLevel].InitialLayout, levels[(int)CurrentLevel].ExploredLayout, levels[(int)CurrentLevel].InitialLayout.Length);
        }
        public void InitializeLevels()
        {
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i].InitialLayout = new Tile[levels[i].Size.Height, levels[i].Size.Width];
                levels[i].ExploredLayout = new Tile[levels[i].Size.Height, levels[i].Size.Width];
                levels[i].Enemies = new Enemy[levels[i].NumberOfEnemies];
                levels[i].PreviousEnemyPositions = new Point[levels[i].Enemies.Length];

                for (int row = 0; row < levels[i].Size.Height; row++)
                {
                    for (int column = 0; column < levels[i].Size.Width; column++)
                    {
                        if (column == 0 || column == levels[i].Size.Width - 1 || row == 0 || row == levels[i].Size.Height - 1)
                        {
                            levels[i].InitialLayout[row, column] = new Wall(true);
                        }
                        else
                        {
                            levels[i].InitialLayout[row, column] = new Floor();
                        }
                    }
                }
            }
            levelLayout.SetLevelOneLayout();
            levelLayout.SetLevelTwoLayout();
        }
    }
}
