using System;
namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Level[] gameLevels = new Level[3];
            gameLevels = LevelCreator.GetLevels();
            GameplayManager gameplayManager = new GameplayManager(gameLevels);
            gameplayManager.CurrentState = GameplayState.InitializeLevel;

            SetConsoleProperties();
            WelcomeScreen();
            while (gameplayManager.CurrentState != GameplayState.ExitGame)
            {              
                gameplayManager.RunState();
                gameplayManager.CurrentState = gameplayManager.CheckState(gameplayManager.CurrentState);
            }
            Console.Clear();
        }
            public static void WelcomeScreen()
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
                Console.Write($"\n\n\n\n\n\t|Legend\n\t|\n\t|Keys: K\n\t|Door: D\n\t|Player: @\n\t|Monsters: M");
                Console.WriteLine("\n\n\n\n\n\n\n\n\tMade by:");
                Console.WriteLine("\tJohn Andersson & Emil Martini");
                Console.ReadKey(true);
                Console.Clear();
            }
            public static void SetConsoleProperties()
            {
                Size consoleWindowSize = new Size(77, 36);
                Console.CursorVisible = false;
                Console.SetWindowSize((int)consoleWindowSize.Width, (int)consoleWindowSize.Height);
                Console.SetBufferSize((int)consoleWindowSize.Width + 1, (int)consoleWindowSize.Height + 1);
            }
    }
}