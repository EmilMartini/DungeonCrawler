using System;
using System.Collections.Generic;
using System.Media;
namespace DungeonCrawler
{
    public class GameplayManager
    {
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

        public GameplayManager(List<Level> levels, Player player)
        {
            SoundPlayer = new SoundPlayer();
            Levels = levels;
            Player = player;
            EnemyController = new EnemyController();
            PlayerController = new PlayerController(Player);
            ConsoleOutputFilter = new ConsoleOutputFilter(); 
        }
        public void RunState()
        {
            switch (CurrentState)
            {
                case GameplayState.InitializeLevel:
                    LevelRenderer.DisplayLevelInfo(this);
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
                    if (Player.Position.Equals(Levels[CurrentLevel].EntryDoor))
                    {
                        if (CurrentLevel - 1 > -1)  
                        {
                            NextLevel = CurrentLevel - 1;
                            return GameplayState.ExitLevel;
                        }
                        else
                        {
                            return GameplayState.ShowScore;
                        }
                    }
                    else if(Player.Position.Equals(Levels[CurrentLevel].ExitDoor))
                    {
                        NextLevel = CurrentLevel + 1;
                        return GameplayState.ExitLevel;
                    }
                    else
                        return GameplayState.RunLevel;

                case GameplayState.ExitLevel:
                    if (SuccesfulExitLevel && NextLevel != Levels.Count + 1)
                    {
                        CurrentLevel = NextLevel;
                        return GameplayState.InitializeLevel;
                    }
                    else if (SuccesfulExitLevel && NextLevel == Levels.Count + 1)
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
                Console.Write($"\n\n\n\n\n\n\n\t\t\t\t  Moves: {Player.NumberOfMoves}\n\n");
                Console.Write($"\t\t\t     Enemies Hit: {Player.EnemiesInteractedWith} * 20\n\n");
                Console.Write($"\t\t\t       Final Score: {(Player.EnemiesInteractedWith * 20) + Player.NumberOfMoves}\n");

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
                LevelRenderer.RenderOuterWalls(this);
                PlayerController.ExploreSurroundingTiles(this);
                LevelRenderer.RenderLevel(this);
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
            EnemyController.MoveEnemies(this);
            PlayerController.MovePlayer(PlayerController.GetInput(), this);
            PlayerController.ExploreSurroundingTiles(this);
            Console.SetOut(standardOutputFilter);
            LevelRenderer.RenderLevel(this);
        }
        void ExitLevel()
        {
            try
            {
                PlayerController.ResetPositionData(this);
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

        public GameplayState CurrentState { get; set; }
        public int CurrentLevel { get; set; }
        public int NextLevel { get; set; }
        public List<Level> Levels { get; set; }
        public Player Player { get; set; }
        public EnemyController EnemyController { get; set; }
        public PlayerController PlayerController { get; set; }
        public ConsoleOutputFilter ConsoleOutputFilter { get; set; }
        public static SoundPlayer SoundPlayer { get; set; }
    }
}
