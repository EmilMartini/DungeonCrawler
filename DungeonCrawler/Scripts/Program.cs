using System;
using System.IO;
namespace DungeonCrawler
{
    class Program
    {
        private static readonly Size consoleWindowSize = new Size(72, 36);
        static void Main(string[] args)
        {
            var levelLayout = new LevelLayout(); 
            var player = new Player(levelLayout.Levels[1].PlayerStartingTile);
            var levelRenderer = new LevelRenderer(levelLayout.Levels[1], player);
            var levelLoader = new LevelLoader(levelLayout.Levels, player, consoleWindowSize);
            var enemyController = new EnemyController(levelLayout.Levels[1], levelRenderer);
            var playerController = new PlayerController(levelLayout.Levels[1], player, levelRenderer);
            var consoleOutputFilter = new ConsoleOutputFilter();

            SetConsoleProperties(consoleWindowSize);
            LoadGameDependecies(levelLayout, levelLoader, levelRenderer);
            RunGame(consoleOutputFilter, Console.Out, playerController, enemyController, levelRenderer);        
        }

        private static void RunGame(ConsoleOutputFilter consoleOutputFilter, TextWriter standardOutputWriter, PlayerController playerController, EnemyController enemyController, LevelRenderer levelRenderer)
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.SetOut(consoleOutputFilter);
                playerController.CheckInput();
                enemyController.Move();
                Console.SetOut(standardOutputWriter);
                levelRenderer.RenderLevel();
            }
        }
        private static void LoadGameDependecies(LevelLayout levelLayout, LevelLoader levelLoader, LevelRenderer levelRenderer)
        {
            levelLayout.InitializeLevels();
            levelLoader.SpawnLevelObjects();
            levelLoader.DisplayInitialMap();
            levelRenderer.ExploreTilesAroundPlayer(levelLayout.Levels[1].PlayerStartingTile);
            levelRenderer.RenderLevel();
        }
        private static void SetConsoleProperties(Size windowSize)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize((int)consoleWindowSize.Width, (int)consoleWindowSize.Height);
            Console.SetBufferSize((int)consoleWindowSize.Width + 1, (int)consoleWindowSize.Height + 1);
        }
    }
}
