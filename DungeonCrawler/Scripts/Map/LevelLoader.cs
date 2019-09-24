using System;
using DungeonCrawler.Doors;
using DungeonCrawler.Keys;

namespace DungeonCrawler
{
    class LevelLoader
    {
        private Level[] levels;
        private readonly Player player;
        private static int currentLevel;
        private readonly Size consoleWindowSize;
        private Random rnd = new Random();

        public LevelLoader(Level[] levels, Player player, Size consoleWindowSize)
        {
            this.levels = levels;
            this.player = player;
            this.consoleWindowSize = consoleWindowSize;
        }
        public static int CurrentLevel
        {
            get { return currentLevel; }
            set { currentLevel = value; }
        }

        public void SpawnLevelObjects()
        {
            //Spawn enemies
            int enemySpawnPositionRow , enemySpawnPositionColumn;
            for (int i = 0; i < levels[currentLevel].Enemies.Length; i++)
            {
                enemySpawnPositionRow = rnd.Next(1, levels[currentLevel].InitialLayout.GetLength(0) - 2);
                enemySpawnPositionColumn = rnd.Next(1, levels[currentLevel].InitialLayout.GetLength(1) - 2);

                levels[currentLevel].Enemies[i] = new Enemy(enemySpawnPositionRow, enemySpawnPositionColumn);
            }

            levels[currentLevel].ExploredLayout[player.Position.row, player.Position.column] = player;
            for (int i = 0; i < levels[currentLevel].Enemies.Length; i++)
            {
                levels[currentLevel].ExploredLayout[levels[currentLevel].Enemies[i].Position.row, levels[currentLevel].Enemies[i].Position.column] = levels[currentLevel].Enemies[i];
            }
            Array.Copy(levels[currentLevel].InitialLayout, levels[currentLevel].ExploredLayout, levels[currentLevel].InitialLayout.Length);
        }

        public void DisplayInitialMap()
        {
            Console.Write("\n \n");
            for (int row = 0; row < levels[currentLevel].ExploredLayout.GetLength(0); row++)
            {
                for (int column = 0; column < levels[currentLevel].ExploredLayout.GetLength(1); column++)
                {
                    Console.SetCursorPosition(((int)consoleWindowSize.Width / levels[currentLevel].ExploredLayout.GetLength(0) * column), ((int)consoleWindowSize.Height / levels[currentLevel].ExploredLayout.GetLength(1) * row));
                    Console.ForegroundColor = levels[currentLevel].ExploredLayout[row, column].Color;
                    if (levels[currentLevel].ExploredLayout[row, column].IsExplored == true)
                    {
                        Console.Write($"{levels[currentLevel].ExploredLayout[row, column].Graphic}");
                    }
                    else
                    {
                        Console.Write($" ");
                    }
                }
                Console.Write("\n \n");
            }
        }
    }
}
