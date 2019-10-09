using System;

namespace DungeonCrawler
{
    /*
    High Score Table
    ----------------
    Alexander

    moves: 409
    enemies hit: 5 * 20
    final score: 509
    ----------------
    Daniel

    moves: 493
    enemies hit: 5 * 20
    final score 593
    ----------------
    Anders

    moves: 705
    enemies hit: 2 * 20
    final score: 745
    ---------------
    */
    class Program
    {
        private static Player player;
        private static GameplayManager gameplayManager;

        private static void Main()
        {
            InitGame();
            SetConsoleProperties();
            WelcomeScreen();
            gameplayManager.Update();
            Console.Clear();
        }

        private static void InitGame()
        {
            var gameLevels = LevelCreator.GetLevels();
            player = new Player();
            gameplayManager = new GameplayManager(gameLevels, player);
            gameplayManager.Init();
        }
        
        private static void WelcomeScreen()
        {
            GameplayManager.PlaySound("welcomescreen-sound");
            Console.WriteLine();
            Console.WriteLine("\tWelcome to a dungeon crawler you'll never forget.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\t@ ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("<- This is you");
            Console.Write("! \n\tCollect keys to advance through the locked doors. \n\tBut be wary, there are ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("monsters ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("lurking these halls....\n");
            Console.Write("\n\n\n\n\n\t|Legend\n\t|\n\t|Keys: K\n\t|Door: D\n\t|Monsters: X\n\t|Potion: P\n\n\n\n");
            Console.WriteLine("\t\t\t\tGood luck!\n");
            Console.WriteLine("\t\t\tPress any key to start...");
            Console.WriteLine("\n\n\n\n\n\n\tMade by:");
            Console.WriteLine("\tJohn Andersson & Emil Martini");
            Console.ReadKey(true);
            Console.Clear();
        }

        private static void SetConsoleProperties()
        {
            var consoleWindowSize = new Size(77, 36);
            Console.CursorVisible = false;
            Console.Title = "Dungeon Crawler 1 : The Beginning";
            Console.SetWindowSize((int) consoleWindowSize.Width, (int) consoleWindowSize.Height);
            Console.SetBufferSize((int) consoleWindowSize.Width + 1, (int) consoleWindowSize.Height + 1);
        }
    }
}