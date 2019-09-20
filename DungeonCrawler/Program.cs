using System;
namespace DungeonCrawler
{
    class Program
    {
        private static readonly Size consoleWindowSize = new Size(72, 36);
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            SetWindowSize(consoleWindowSize);

            var levelLayout = new LevelLayout(); 
            var player = new Player(levelLayout.Levels[0].PlayerStartingTile);

            var levelRenderer = new LevelRenderer(levelLayout.Levels[0], player);
            var levelLoader = new LevelLoader(levelLayout.Levels, player, consoleWindowSize);

            var enemyController = new EnemyController(levelLayout.Levels[0], levelRenderer);
            var playerController = new PlayerController(levelLayout.Levels[0], player, levelRenderer);

            levelLayout.InitializeLevels();
            levelLoader.SpawnLevelObjects();
            levelLoader.DisplayInitialMap();
            levelRenderer.GetTilesToExplore(levelLayout.Levels[0].PlayerStartingTile);
            levelRenderer.RenderLevel();
            enemyController.Move();


            Console.CursorVisible = false;
            var standardOutputWriter = Console.Out;
            var consoleOutputFilter = new ConsoleOutputFilter();

            while(true)
            {
                Console.SetOut(consoleOutputFilter);
                playerController.CheckInput();
                Console.SetOut(standardOutputWriter);
                levelRenderer.RenderLevel();
            }            
        }

        private static void SetWindowSize(Size windowSize)
        {
            Console.SetWindowSize((int)consoleWindowSize.Width, (int)consoleWindowSize.Height);
            Console.SetBufferSize((int)consoleWindowSize.Width + 1, (int)consoleWindowSize.Height + 1);
        }
    }
}
