using System;
using DungeonCrawler.Doors;
using DungeonCrawler.Keys;

namespace DungeonCrawler
{
    public class LevelLoader
    {
        private StateMachine stateMachine;
        private Level[] levels;
        private readonly LevelLayout levelLayout;
        private Random rnd = new Random();

        public LevelLoader(LevelLayout levelLayout, StateMachine stateMachine)
        {
            this.levels = stateMachine.Levels;
            this.levelLayout = levelLayout;
            this.stateMachine = stateMachine;
        }
        public void SpawnLevelObjects()
        {
            //Spawn enemies
            int enemySpawnPositionRow, enemySpawnPositionColumn;
            for (int i = 0; i < levels[(int)stateMachine.LevelIndex].Enemies.Length; i++)
            {
                enemySpawnPositionRow = rnd.Next(1, levels[(int)stateMachine.LevelIndex].InitialLayout.GetLength(0) - 2);
                enemySpawnPositionColumn = rnd.Next(1, levels[(int)stateMachine.LevelIndex].InitialLayout.GetLength(1) - 2);

                levels[(int)stateMachine.LevelIndex].Enemies[i] = new Enemy(enemySpawnPositionRow, enemySpawnPositionColumn);
            }

            levels[(int)stateMachine.LevelIndex].ExploredLayout[stateMachine.Levels[(int)stateMachine.LevelIndex].PlayerStartingTile.row, stateMachine.Levels[(int)stateMachine.LevelIndex].PlayerStartingTile.column] = new Player();

            for (int i = 0; i < levels[(int)stateMachine.LevelIndex].Enemies.Length; i++)
            {
                levels[(int)stateMachine.LevelIndex].ExploredLayout[levels[(int)stateMachine.LevelIndex].Enemies[i].Position.row, levels[(int)stateMachine.LevelIndex].Enemies[i].Position.column] = levels[(int)stateMachine.LevelIndex].Enemies[i];
            }
            Array.Copy(levels[(int)stateMachine.LevelIndex].InitialLayout, levels[(int)stateMachine.LevelIndex].ExploredLayout, levels[(int)stateMachine.LevelIndex].InitialLayout.Length);
        }
        public void InitializeLevels()
        {
            for (int i = 0; i < stateMachine.Levels.Length; i++)
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
            levelLayout.SetLevelThreeLayout();
        }
    }
}
