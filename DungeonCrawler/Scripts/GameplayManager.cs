using System;
using System.Media;
using System.Threading;
namespace DungeonCrawler
{
    public class GameplayManager
    {
        private static SoundPlayer soundPlayer;
        private Player player;      
        private LevelRenderer levelRenderer;
        private EnemyController enemyController;
        private PlayerController playerController;
        private ConsoleOutputFilter consoleOutputFilter;  
        private Level[] levels;
        private int currentLevel;
        private int nextLevel;
        private GameplayState currentState;
        private bool SuccessfulLoadLevel;
        private bool SuccesfulExitLevel;
        private bool SuccesfulDisplayScore;

        //brytit ut level skapandet till en klass. inte ha det i tre olika metoder
        //och så hade jag se till att enemycontroller och player controller manipulerar gameplay datan
        //och sedana så hade gameplaymanagern läst av hela staten och sedan bestämt om vi ska byta state(typ, win, dö, nextlevel, vad det nu är).
        //och renderaren bör va separat ifrån level logiken. utan bör bara ta in all gameplaydata och rendera, då kan ni lägga in consoleoutput filter overriden där med
        // exit early prylarna
        //dvs:
        //en klass för levelcreation
        //en klass för rendering
        //en klass för gamestaten / level / activeLevel
        public GameplayManager(Level[] levels)
        {
            this.Levels = levels;
            Player = new Player();
            LevelRenderer = new LevelRenderer(Levels, player);
            EnemyController = new EnemyController(this);
            PlayerController = new PlayerController(Player, this);
            ConsoleOutputFilter = new ConsoleOutputFilter(); 
            SoundPlayer = new SoundPlayer();
            currentLevel = default;
        }
        public void RunState()
        {
            switch (CurrentState)
            {
                case GameplayState.InitializeLevel:
                    DisplayLevelInfo();
                    LoadCurrentLevel();
                    break;
                case GameplayState.RunLevel:
                    RunGame(Console.Out);
                    break;
                case GameplayState.ExitLevel:
                    ExitLevel();
                    break;
                case GameplayState.ShowScore:
                    DisplayScore();
                    break;
            }
        }
        private void DisplayScore()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\n\n\n\n\n\n\n\t\t\t\t   Moves: {player.NumberOfMoves}\n\n");
                Console.Write($"\t\t\t     Enemies Hit: {player.EnemiesInteractedWith} * 20\n\n");
                Console.Write($"\t\t\t       Final Score: {(player.EnemiesInteractedWith * 20) + player.NumberOfMoves}\n");

                Console.WriteLine("\n\n\n\t\t\t  Press any key to exit game...");
                Console.ReadKey();
                SuccesfulDisplayScore = true;
            }
            catch (Exception)
            {
                SuccesfulDisplayScore = false;
            }
        }
        void LoadCurrentLevel()
        {
            try
            {
                LevelRenderer.RenderOuterWalls(currentLevel);
                PlayerController.ExploreSurroundingTiles();
                LevelRenderer.RenderLevel(currentLevel);
                SuccessfulLoadLevel = true;
            }
            catch (Exception)
            {
                SuccessfulLoadLevel = false;
            }
        }
        void RunGame(System.IO.TextWriter standardOutputFilter)
        {
            Console.SetOut(ConsoleOutputFilter);
            EnemyController.MoveEnemies();
            PlayerController.MovePlayer(PlayerController.GetInput());
            PlayerController.ExploreSurroundingTiles();
            Console.SetOut(standardOutputFilter);
            LevelRenderer.RenderLevel(currentLevel);
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
            try
            {
                PlayerController.ResetPositionData();
                Console.Clear();
                SuccesfulExitLevel = true;
            }
            catch (Exception)
            {
                SuccesfulExitLevel = false;
            }
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
        public GameplayState CheckState(GameplayState currentState)
        {
            switch (currentState)
            {
                case GameplayState.InitializeLevel:
                    if (SuccessfulLoadLevel)
                        return GameplayState.RunLevel;
                    else
                        return GameplayState.InitializeLevel;

                case GameplayState.RunLevel:
                    if (player.Position.Equals(levels[currentLevel].EntryDoor))
                    {
                        if (currentLevel - 1 > -1)
                        {
                            nextLevel = currentLevel - 1;
                            return GameplayState.ExitLevel;
                        } else
                        {
                            return GameplayState.ShowScore;
                        }
                    } else if(player.Position.Equals(levels[currentLevel].ExitDoor))
                    {
                        nextLevel = currentLevel + 1;
                        return GameplayState.ExitLevel;
                    }
                    else
                        return GameplayState.RunLevel;

                case GameplayState.ExitLevel:
                    if (SuccesfulExitLevel && nextLevel != 4)
                    {
                        currentLevel = nextLevel;
                        return GameplayState.InitializeLevel;
                    } else if (SuccesfulExitLevel && nextLevel == 4)
                    {
                        return GameplayState.ShowScore;
                    }
                    else
                        return GameplayState.ExitLevel;

                case GameplayState.ShowScore:
                    if (SuccesfulDisplayScore)
                        return GameplayState.ExitGame;
                    else
                        return GameplayState.ShowScore;

                default:
                    return GameplayState.InitializeLevel;
            }
        }
        public GameplayState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }
        public int CurrentLevel
        {
            get { return currentLevel; }
            set { currentLevel = value; }
        }
        public int NextLevel
        {
            get { return nextLevel; }
            set { nextLevel = value; }
        }
        public Level[] Levels
        {
            get { return levels; }
            set { levels = value; }
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
