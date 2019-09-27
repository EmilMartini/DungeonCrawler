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
        private Random rnd = new Random();

        public LevelLoader(Level[] levels, Player player)
        {
            this.levels = levels;
            this.player = player;
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
            for (int i = 0; i < levels[CurrentLevel].Enemies.Length; i++)
            {
                enemySpawnPositionRow = rnd.Next(1, levels[CurrentLevel].InitialLayout.GetLength(0) - 2);
                enemySpawnPositionColumn = rnd.Next(1, levels[CurrentLevel].InitialLayout.GetLength(1) - 2);

                levels[CurrentLevel].Enemies[i] = new Enemy(enemySpawnPositionRow, enemySpawnPositionColumn);
            }

            levels[CurrentLevel].ExploredLayout[player.Position.row, player.Position.column] = player;

            for (int i = 0; i < levels[CurrentLevel].Enemies.Length; i++)
            {
                levels[CurrentLevel].ExploredLayout[levels[CurrentLevel].Enemies[i].Position.row, levels[CurrentLevel].Enemies[i].Position.column] = levels[CurrentLevel].Enemies[i];
            }
            Array.Copy(levels[CurrentLevel].InitialLayout, levels[CurrentLevel].ExploredLayout, levels[CurrentLevel].InitialLayout.Length);
        }

        public void DisplayInitialMap()
        {
            Console.Write("\n \n");
            for (int row = 0; row < levels[CurrentLevel].InitialLayout.GetLength(0); row++)
            {
                for (int column = 0; column < levels[CurrentLevel].InitialLayout.GetLength(1); column++)
                {
                    Console.SetCursorPosition(column + (column + 2), row);

                    Console.ForegroundColor = levels[CurrentLevel].InitialLayout[row, column].Color;
                    if (levels[CurrentLevel].InitialLayout[row, column].IsExplored == true)
                    {
                        Console.Write($"{levels[CurrentLevel].InitialLayout[row, column].Graphic}");
                    }
                    else
                    {
                        Console.Write($"");
                    }
                }
                Console.Write("");
            }
        }
    }
}
