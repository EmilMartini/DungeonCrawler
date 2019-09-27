using DungeonCrawler.Scripts;
using System;
using System.Media;
using System.Threading;

namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            StateMachine stateMachine = new StateMachine();
            DataInitializer dataInitializer = new DataInitializer(stateMachine);
            stateMachine.DataInitializer = dataInitializer;

            while (stateMachine.CurrentState != StateMachine.State.ExitGame)
            {              
                RunState(stateMachine);
            }        
        }
        static void SetConsoleProperties()
        {
            Size consoleWindowSize = new Size(77, 36);
            Console.CursorVisible = false;
            Console.SetWindowSize((int)consoleWindowSize.Width, (int)consoleWindowSize.Height);
            Console.SetBufferSize((int)consoleWindowSize.Width + 1, (int)consoleWindowSize.Height + 1);
        }
        static void LoadGameDependencies(StateMachine stateMachine)
        {
            stateMachine.DataInitializer.LevelLoader.InitializeLevels();
            stateMachine.CurrentState = StateMachine.State.WelcomeScreen;
        }
        static void WelcomeScreen(StateMachine stateMachine)
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
            stateMachine.CurrentState = StateMachine.State.InitializeLevel;
        }
        static void LoadCurrentLevel(StateMachine stateMachine)
        {
            stateMachine.DataInitializer.LevelLoader.SpawnLevelObjects();
            stateMachine.DataInitializer.LevelRenderer.RenderInitialExploredTiles();
            stateMachine.DataInitializer.LevelRenderer.RenderLevel();
            stateMachine.CurrentState = StateMachine.State.RunLevel;
        }
        static void RunGame(StateMachine stateMachine)
        {
                Console.SetOut(stateMachine.DataInitializer.ConsoleOutputFilter);
                stateMachine.DataInitializer.PlayerController.MovePlayer(stateMachine.DataInitializer.PlayerController.GetInput());
                stateMachine.DataInitializer.EnemyController.Move();
                stateMachine.DataInitializer.PlayerController.ExploreTilesAroundPlayer();
                Console.SetOut(stateMachine.StandardOutputWriter);
                stateMachine.DataInitializer.LevelRenderer.RenderLevel();
        }    
        static void RunState(StateMachine stateMachine)
        {
            switch (stateMachine.CurrentState)
            {
                case StateMachine.State.InitializeGame:
                    SetConsoleProperties();
                    LoadGameDependencies(stateMachine);
                    break;
                case StateMachine.State.WelcomeScreen:
                    WelcomeScreen(stateMachine);
                    break;
                case StateMachine.State.InitializeLevel:
                    LoadCurrentLevel(stateMachine);
                    break;
                case StateMachine.State.RunLevel:
                    RunGame(stateMachine);
                    break;
                case StateMachine.State.ExitLevel:

                    break;
                case StateMachine.State.ExitGame:

                    break;
            }
        }
    }
}