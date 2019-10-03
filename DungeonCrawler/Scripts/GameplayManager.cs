using System;
using System.Media;
using System.Threading;
namespace DungeonCrawler
{
    public class GameplayManager
    {
        private static SoundPlayer soundPlayer;
        private LevelLayout levelLayout;   
        private Player player;      
        private LevelRenderer levelRenderer;
        private LevelController levelController;
        private EnemyController enemyController;
        private PlayerController playerController;
        private ConsoleOutputFilter consoleOutputFilter;  
        private Level[] levels;
        private CurrentLevel currentLevel;
        private CurrentLevel nextLevel;
        private State currentState;

        public GameplayManager()
        {
            LevelLayout = new LevelLayout(this);
            Player = new Player();
            LevelRenderer = new LevelRenderer(Levels, player, this);
            LevelController = new LevelController(LevelLayout, this);
            EnemyController = new EnemyController(this);
            PlayerController = new PlayerController(Player, this);
            ConsoleOutputFilter = new ConsoleOutputFilter();
            SoundPlayer = new SoundPlayer();
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
                case State.ShowScore:
                    DisplayScore();
                    break;
                case State.ExitGame:
                    break;
            }
        }
        private void DisplayScore()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\n\n\n\n\n\n\n\t\t\t\t   Moves: {player.NumberOfMoves}\n\n");
            Console.Write($"\t\t\t     Enemies Hit: {player.EnemiesInteractedWith} * 20\n\n");
            Console.Write($"\t\t\t       Final Score: {(player.EnemiesInteractedWith * 20) + player.NumberOfMoves}\n");

            Console.WriteLine("\n\n\n\t\t\t  Press any key to exit game...");
            Console.ReadKey();
            CurrentState = State.ExitGame;
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
            LevelController.InitializeLevels();
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
            LevelRenderer.RenderOuterWalls();
            PlayerController.ExploreSurroundingTiles();
            LevelRenderer.RenderLevel();
            CurrentState = State.RunLevel;
        }
        void RunGame(System.IO.TextWriter standardOutputFilter)
        {
            Console.SetOut(ConsoleOutputFilter);
            EnemyController.MoveEnemies();
            PlayerController.MovePlayer(PlayerController.GetInput());
            if (CurrentState == State.ExitLevel)
            {
                Console.SetOut(standardOutputFilter);
                return;
            }
            PlayerController.ExploreSurroundingTiles();
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
            PlaySound("open-close-door");
            Console.Clear();
        }
        void ExitLevel()
        {
            PlayerController.ResetPositionData();
            CurrentLevel = NextLevel;
            CurrentState = State.InitializeLevel;
            Console.Clear();
        }
        public void RemoveGameObject(GameObject objectToRemove)
        {
            if(Levels[(int)CurrentLevel].ActiveGameObjects.Contains(objectToRemove))
            {
                Levels[(int)CurrentLevel].ActiveGameObjects.Remove(objectToRemove);
            } else
            {
                return;
            }
        }
        public void UnlockHiddenDoor(Door doorToUnlock)
        {
            doorToUnlock.IsUnlocked = true;
        }
        public static void PlaySound(string fileName)
        {
            SoundPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\" + fileName + ".wav";
            SoundPlayer.Play();
        }

        public State CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }
        public CurrentLevel CurrentLevel
        {
            get { return currentLevel; }
            set { currentLevel = value; }
        }
        public Level[] Levels
        {
            get { return levels; }
            set { levels = value; }
        }
        public CurrentLevel NextLevel
        {
            get { return nextLevel; }
            set { nextLevel = value; }
        }
        public LevelLayout LevelLayout
        {
            get { return levelLayout; }
            set { levelLayout = value; }
        }
        public Player Player
        {
            get { return player; }
            set { player = value; }
        }
        public LevelRenderer LevelRenderer
        {
            get { return levelRenderer; }
            set { levelRenderer = value; }
        }
        public LevelController LevelController
        {
            get { return levelController; }
            set { levelController = value; }
        }
        public EnemyController EnemyController
        {
            get { return enemyController; }
            set { enemyController = value; }
        }
        public PlayerController PlayerController
        {
            get { return playerController; }
            set { playerController = value; }
        }
        public ConsoleOutputFilter ConsoleOutputFilter
        {
            get { return consoleOutputFilter; }
            set { consoleOutputFilter = value; }
        }
        public static SoundPlayer SoundPlayer
        {
            get { return soundPlayer; }
            set { soundPlayer = value; }
        }
    }
}
