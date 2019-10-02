﻿using System;
namespace DungeonCrawler
{
    public class LevelLoader
    {
        private GameplayManager gameplayManager;
        private Level[] levels;
        private readonly LevelLayout levelLayout;
        private Random rnd = new Random();
        public LevelLoader(LevelLayout levelLayout, GameplayManager gameplayManager)
        {
            this.levels = gameplayManager.Levels;
            this.levelLayout = levelLayout;
            this.gameplayManager = gameplayManager;
        }
        public void InitializeLevels()
        {
            for (int i = 0; i < gameplayManager.Levels.Length; i++)
            {
                levels[i].InitialLayout = new Tile[levels[i].Size.Height, levels[i].Size.Width];
                levels[i].ExploredLayout = new Tile[levels[i].Size.Height, levels[i].Size.Width];

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

                //Spawn enemies
                for (int enemyIndex = 0; enemyIndex < levels[i].NumberOfEnemies; enemyIndex++)
                {
                    int enemySpawnPositionRow, enemySpawnPositionColumn;
                    enemySpawnPositionRow = rnd.Next(1, levels[i].InitialLayout.GetLength(0) - 2);
                    enemySpawnPositionColumn = rnd.Next(1, levels[i].InitialLayout.GetLength(1) - 2);

                    levels[i].ActiveGameObjects.Add(new Enemy(enemySpawnPositionRow, enemySpawnPositionColumn));
                }
            }
            levelLayout.SetLevelOneLayout();
            levelLayout.SetLevelTwoLayout();
            levelLayout.SetLevelThreeLayout();
        }
        internal void SpawnLevelObjects()
        {
            Array.Copy(levels[(int)gameplayManager.CurrentLevel].InitialLayout, levels[(int)gameplayManager.CurrentLevel].ExploredLayout, levels[(int)gameplayManager.CurrentLevel].InitialLayout.Length);
        }
    }
}
