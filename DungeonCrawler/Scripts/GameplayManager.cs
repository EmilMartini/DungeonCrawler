using System;
using System.Media;
using System.Threading;
namespace DungeonCrawler
{
    public class GameplayManager
    {
        private static SoundPlayer soundPlayer;
        static GameplayManager instance;
        private Player player;      
        private EnemyController enemyController;
        private PlayerController playerController;
        private ConsoleOutputFilter consoleOutputFilter;  
        private Level[] levels;
        private GameplayState currentState;
        private int currentLevel;
        private int nextLevel;
        private bool SuccessfulLoadLevel;
        private bool SuccesfulExitLevel;
        private bool SuccesfulDisplayScore;

        //DONE// brytit ut level skapandet till en klass. inte ha det i tre olika metoder

        //DONE// och så hade jag se till att enemycontroller och player controller manipulerar gameplay datan
        //DONE// och sedana så hade gameplaymanagern läst av hela staten och sedan bestämt om vi ska byta state(typ, win, dö, nextlevel, vad det nu är).
        //DONE// och renderaren bör va separat ifrån level logiken. utan bör bara ta in all gameplaydata och rendera, då kan ni lägga in consoleoutput filter overriden där med
        //DONE// dvs:
        //DONE// en klass för levelcreation
        //DONE// en klass för rendering

        // typ done// en klass för gamestaten / level / activeLevel
        // exit early prylarna
        // fixa dependencies

        public GameplayManager(Level[] levels, Player player)
        {
            SoundPlayer = new SoundPlayer();
            Levels = levels;
            Player = player;
            EnemyController = new EnemyController();
            PlayerController = new PlayerController(Player);
            ConsoleOutputFilter = new ConsoleOutputFilter(); 
            currentLevel = default;
            Instance = this;
        }
        public void RunState()
        {
            switch (CurrentState)
            {
                case GameplayState.InitializeLevel:
                    LevelRenderer.DisplayLevelInfo(Instance);
                    LoadCurrentLevel(Instance);
                    break;
                case GameplayState.RunLevel:
                    RunGame(Console.Out, Instance);
                    break;
                case GameplayState.ExitLevel:
                    ExitLevel(Instance);
                    break;
                case GameplayState.ShowScore:
                    DisplayScore();
                    break;
            }
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
                    if (SuccesfulExitLevel && nextLevel != levels.Length + 1)
                    {
                        currentLevel = nextLevel;
                        return GameplayState.InitializeLevel;
                    } else if (SuccesfulExitLevel && nextLevel == levels.Length + 1)
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

        void DisplayScore()
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
        void LoadCurrentLevel(GameplayManager gameplayManager)
        {
            try
            {
                LevelRenderer.RenderOuterWalls(gameplayManager);
                PlayerController.ExploreSurroundingTiles(gameplayManager);
                LevelRenderer.RenderLevel(gameplayManager);
                SuccessfulLoadLevel = true;
            }
            catch (Exception)
            {
                SuccessfulLoadLevel = false;
            }
        }
        void RunGame(System.IO.TextWriter standardOutputFilter, GameplayManager gameplayManager)
        {
            Console.SetOut(ConsoleOutputFilter);
            EnemyController.MoveEnemies(gameplayManager);
            PlayerController.MovePlayer(PlayerController.GetInput(), gameplayManager);
            PlayerController.ExploreSurroundingTiles(gameplayManager);
            Console.SetOut(standardOutputFilter);
            LevelRenderer.RenderLevel(gameplayManager);
        }
        void ExitLevel(GameplayManager gameplayManager)
        {
            try
            {
                PlayerController.ResetPositionData(gameplayManager);
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
        public static void PlaySound(string fileName)
        {
            SoundPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\" + fileName + ".wav";
            SoundPlayer.Play();
        }
        public void Update()
        {
            while (CurrentState != GameplayState.ExitGame)
            {
                RunState();
                CurrentState = CheckState(CurrentState);
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
        public static GameplayManager Instance
        {
            get { return instance; }
            set { instance = value; }
        }
    }
}
