using System;
using System.Media;
using System.Threading;

namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var levelLayout = new LevelLayout(); 
            var player = new Player();
            var levelRenderer = new LevelRenderer(levelLayout.Levels, player);
            var levelLoader = new LevelLoader(levelLayout.Levels, player);
            var enemyController = new EnemyController(levelLayout.Levels, levelRenderer);
            var playerController = new PlayerController(levelLayout.Levels, player, levelRenderer);
            var consoleOutputFilter = new ConsoleOutputFilter();

            SetConsoleProperties();
            WelcomeScreen();
            LoadGameDependecies(levelLayout, levelLoader, levelRenderer);
            RunGame(consoleOutputFilter, Console.Out, playerController, enemyController, levelRenderer, player);        
        }

        private static void RunGame(ConsoleOutputFilter consoleOutputFilter, System.IO.TextWriter standardOutputWriter, PlayerController playerController, EnemyController enemyController, LevelRenderer levelRenderer, Player player)
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.SetOut(consoleOutputFilter);
                playerController.CheckInput();
                enemyController.Move();
                playerController.ExploreTilesAroundPlayer(player.Position);
                Console.SetOut(standardOutputWriter);
                levelRenderer.RenderLevel();
            }
        }
        private static void LoadGameDependecies(LevelLayout levelLayout, LevelLoader levelLoader, LevelRenderer levelRenderer)
        {
            LevelLoader.CurrentLevel = 0;
            levelLayout.InitializeLevels();
            levelLoader.SpawnLevelObjects();
            levelLoader.DisplayInitialMap();
            levelRenderer.RenderLevel();
        }
        private static void SetConsoleProperties()
        {
            Size consoleWindowSize = new Size(77, 36);
            Console.CursorVisible = false;
            Console.SetWindowSize((int)consoleWindowSize.Width, (int)consoleWindowSize.Height);
            Console.SetBufferSize((int)consoleWindowSize.Width + 1, (int)consoleWindowSize.Height + 1);
        }
        private static void WelcomeScreen()
        {
            Console.WriteLine();
            Console.WriteLine($"\tWelcome to a dungeon crawler you'll never forget.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\t@ ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"<- This is you");
            Console.Write("! \n\tCollect keys to advance through the locked doors. \n\tBut be wary, there are ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("monsters ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("lurking these halls....\n\n\n\t\t\t\tGood luck!\n");
            Console.WriteLine("\t\t\tPress any key to start...");
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\tMade by:");
            Console.WriteLine("\tJohn Andersson & Emil Martini");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
