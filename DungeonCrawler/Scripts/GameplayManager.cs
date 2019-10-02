﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class GameplayManager
    {
        private LevelLayout levelLayout;
        private Player player;
        private LevelRenderer levelRenderer;
        private LevelLoader levelLoader;
        private EnemyController enemyController;
        private PlayerController playerController;
        private ConsoleOutputFilter consoleOutputFilter;
        private Level[] levels;
        private Point[] pointsToRenderOnMap;
        private CurrentLevel currentLevel;
        private CurrentLevel nextLevel;
        private State currentState;

        public GameplayManager()
        {
            LevelLayout = new LevelLayout(this);
            Player = new Player();
            LevelRenderer = new LevelRenderer(Levels, player, this);
            LevelLoader = new LevelLoader(LevelLayout, this);
            EnemyController = new EnemyController(this);
            PlayerController = new PlayerController(Player, this);
            ConsoleOutputFilter = new ConsoleOutputFilter();
        }

        public void RunState()
        {
            switch (CurrentState)
            {
                case State.InitializeGame:
                    SetConsoleProperties();
                    LoadGameDependencies();
                    break;
                case State.WelcomeScreen:
                    WelcomeScreen();
                    break;
                case State.InitializeLevel:
                    DisplayLevelInfo();
                    LoadCurrentLevel();
                    break;
                case State.RunLevel:
                    RunGame(Console.Out);
                    break;
                case State.ExitLevel:
                    ExitLevel();
                    break;
                case State.ExitGame:
                    break;
            }
        }
        void SetConsoleProperties()
        {
            Size consoleWindowSize = new Size(77, 36);
            Console.CursorVisible = false;
            Console.SetWindowSize((int)consoleWindowSize.Width, (int)consoleWindowSize.Height);
            Console.SetBufferSize((int)consoleWindowSize.Width + 1, (int)consoleWindowSize.Height + 1);
        }
        void LoadGameDependencies()
        {
            LevelLoader.InitializeLevels();
            CurrentState = State.WelcomeScreen;
        }
        void WelcomeScreen()
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
            CurrentState = State.InitializeLevel;
        }
        void LoadCurrentLevel()
        {
            LevelLoader.SpawnLevelObjects();
            LevelRenderer.RenderOuterWalls();
            PlayerController.ExploreTilesAroundPlayer();
            LevelRenderer.RenderTilesAroundPlayer();
            LevelRenderer.RenderLevel();
            CurrentState = State.RunLevel;
        }
        void RunGame(System.IO.TextWriter standardOutputFilter)
        {
            Console.SetOut(ConsoleOutputFilter);
            EnemyController.Move();
            PlayerController.MovePlayer(PlayerController.GetInput());
            if (CurrentState == State.ExitLevel)
            {
                Console.SetOut(standardOutputFilter);
                return;
            }
            PlayerController.ExploreTilesAroundPlayer();
            Console.SetOut(standardOutputFilter);
            LevelRenderer.RenderLevel();
        }
        void DisplayLevelInfo()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine($"\n\n\n\n\n\n\n\t\t\t       Entering level {(int)CurrentLevel + 1}");
            Console.WriteLine($"\t\t\t          Good Luck");
            Thread.Sleep(2500);
            Console.Clear();
        }
        void ExitLevel()
        {
            PlayerController.ResetPlayerData();
            CurrentLevel = NextLevel;
            CurrentState = State.InitializeLevel;
            Console.Clear();
        }


        public State CurrentState { get { return currentState; } set { currentState = value; } }
        public CurrentLevel CurrentLevel { get { return currentLevel; } set { currentLevel = value; } }
        public Point[] PointsToRenderOnMap { get { return pointsToRenderOnMap; } set { pointsToRenderOnMap = value; } }
        public Level[] Levels { get { return levels; } set { levels = value; } }
        public CurrentLevel NextLevel { get { return nextLevel; } set { nextLevel = value; } }
        public LevelLayout LevelLayout { get { return levelLayout; } set { levelLayout = value; } }
        public Player Player { get => player; set => player = value; }
        public LevelRenderer LevelRenderer { get => levelRenderer; set => levelRenderer = value; }
        public LevelLoader LevelLoader { get => levelLoader; set => levelLoader = value; }
        public EnemyController EnemyController { get => enemyController; set => enemyController = value; }
        public PlayerController PlayerController { get => playerController; set => playerController = value; }
        public ConsoleOutputFilter ConsoleOutputFilter { get => consoleOutputFilter; set => consoleOutputFilter = value; }
    }
}