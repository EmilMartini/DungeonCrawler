using System;
using System.Media;
namespace DungeonCrawler
{
    class Program
    {
        public static SoundPlayer SoundPlayer = new SoundPlayer();
        private static readonly Size consoleWindowSize = new Size(72, 36);
        static void Main(string[] args)
        {
            SoundPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\main-theme.wav";
            SoundPlayer.Play();
            var levelLayout = new LevelLayout(); 
            var player = new Player(levelLayout.Levels[0].PlayerStartingTile);
            var levelRenderer = new LevelRenderer(levelLayout.Levels[0], player);
            var levelLoader = new LevelLoader(levelLayout.Levels, player, consoleWindowSize);
            var enemyController = new EnemyController(levelLayout.Levels[0], levelRenderer);
            var playerController = new PlayerController(levelLayout.Levels[0], player, levelRenderer);
            var consoleOutputFilter = new ConsoleOutputFilter();

            SetConsoleProperties(consoleWindowSize);
            WelcomeScreen();
            LoadGameDependecies(levelLayout, levelLoader, levelRenderer);
            RunGame(consoleOutputFilter, Console.Out, playerController, enemyController, levelRenderer);        
        }

        private static void RunGame(ConsoleOutputFilter consoleOutputFilter, System.IO.TextWriter standardOutputWriter, PlayerController playerController, EnemyController enemyController, LevelRenderer levelRenderer)
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.SetOut(standardOutputWriter);
                levelRenderer.RenderLevel();
                Console.SetOut(consoleOutputFilter);
                playerController.CheckInput();
                enemyController.Move();
            }
        }
        private static void LoadGameDependecies(LevelLayout levelLayout, LevelLoader levelLoader, LevelRenderer levelRenderer)
        {
            levelLayout.InitializeLevels();
            levelLoader.SpawnLevelObjects();
            levelLoader.DisplayInitialMap();
            levelRenderer.ExploreTilesAroundPlayer(levelLayout.Levels[0].PlayerStartingTile);
            levelRenderer.RenderLevel();
        }
        private static void SetConsoleProperties(Size windowSize)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize((int)consoleWindowSize.Width, (int)consoleWindowSize.Height);
            Console.SetBufferSize((int)consoleWindowSize.Width + 1, (int)consoleWindowSize.Height + 1);
        }

        private static void WelcomeScreen()
        {
            Console.WriteLine();
            Console.WriteLine($"\tWelcome to a dungeon crawler you'll never forget.");
            Console.Write($"\tThis is you");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" @");
            Console.ForegroundColor = ConsoleColor.White;
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
