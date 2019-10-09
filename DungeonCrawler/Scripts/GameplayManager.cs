using System;
using System.Collections.Generic;
using System.IO;
using System.Media;

namespace DungeonCrawler
{
    public class GameplayManager
    {
        private bool successfulDisplayScore;
        private bool successfulLoadLevel;
        private bool successfulExitLevel;

        public GameplayManager(List<Level> levels, Player player)
        {
            SoundPlayer = new SoundPlayer();
            Levels = levels;
            Player = player;
            EnemyController = new EnemyController();
            PlayerController = new PlayerController(Player);
            ConsoleOutputFilter = new ConsoleOutputFilter();
            Renderer = new Renderer(this);
        }
        private Renderer Renderer { get; set; } 
        private GameplayState CurrentState { get; set; }
        private EnemyController EnemyController { get; set; }
        private PlayerController PlayerController { get; set; }
        private ConsoleOutputFilter ConsoleOutputFilter { get; set; }
        private static SoundPlayer SoundPlayer { get; set; }
        public List<Level> Levels { get; private set; }
        public Player Player { get; private set; }
        public int CurrentLevel { get; private set; }
        public int NextLevel { get; private set; }

        public static void PlaySound(string fileName)
        {
            SoundPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\" + fileName + ".wav";
            SoundPlayer.Play();
        }
        public void Init()
        {
            CurrentState = GameplayState.InitializeLevel;
        }
        public void RemoveGameObject(GameObject objectToRemove)
        {
            if (Levels[CurrentLevel].ActiveGameObjects.Contains(objectToRemove))
                Levels[CurrentLevel].ActiveGameObjects.Remove(objectToRemove);
        }

        public void Update()
        {
            while (CurrentState != GameplayState.ExitGame)
            {
                RunState();
                CurrentState = CheckState(CurrentState);
            }
        }

        private void RunState()
        {
            switch (CurrentState)
            {
                case GameplayState.InitializeLevel:
                    Renderer.DisplayLevelInfo();
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

        private GameplayState CheckState(GameplayState currentState)
        {
            switch (currentState)
            {
                case GameplayState.InitializeLevel:
                    return this.successfulLoadLevel ? GameplayState.RunLevel : GameplayState.InitializeLevel;

                case GameplayState.RunLevel:
                    if (Player.Position.Equals(Levels[CurrentLevel].EntryDoor))
                    {
                        if (CurrentLevel - 1 <= -1)
                            return GameplayState.ShowScore;

                        NextLevel = CurrentLevel - 1;
                        return GameplayState.ExitLevel;
                    }
                    else if (Player.Position.Equals(Levels[CurrentLevel].ExitDoor))
                    {
                        NextLevel = CurrentLevel + 1;
                        return GameplayState.ExitLevel;
                    }
                    else
                        return GameplayState.RunLevel;

                case GameplayState.ExitLevel:
                    if (this.successfulExitLevel && NextLevel != Levels.Count)
                    {
                        CurrentLevel = NextLevel;
                        return GameplayState.InitializeLevel;
                    }
                    else if (this.successfulExitLevel && NextLevel >= Levels.Count)
                    {
                        return GameplayState.ShowScore;
                    }
                    else
                        return GameplayState.ExitLevel;

                case GameplayState.ShowScore:
                    return this.successfulDisplayScore ? GameplayState.ExitGame : GameplayState.ShowScore;

                default:
                    return GameplayState.InitializeLevel;
            }
        }
        
        private void DisplayScore()
        {           
            this.successfulDisplayScore = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\n\n\n\n\n\n\n\t\t\t\t  Moves: {Player.NumberOfMoves}\n\n");
            Console.Write($"\t\t\t     Enemies Hit: {Player.EnemiesInteractedWith} * 20\n\n");
            Console.Write(
                $"\t\t\t       Final Score: {(Player.EnemiesInteractedWith * 20) + Player.NumberOfMoves}\n");

            Console.WriteLine("\n\n\n\t\t\t  Press any key to exit game...");
            Console.ReadKey();
            this.successfulDisplayScore = true;            
        }

        private void LoadCurrentLevel()
        {
            this.successfulLoadLevel = false;
            Renderer.RenderOuterWalls();
            PlayerController.ExploreSurroundingTiles(this);
            Renderer.RenderLevel();
            this.successfulLoadLevel = true;

        }

        private void RunGame(TextWriter standardOutputFilter)
        {
            Console.SetOut(ConsoleOutputFilter);
            EnemyController.MoveEnemies(this);
            PlayerController.UpdatePlayer(PlayerController.GetInput(), this);
            PlayerController.ExploreSurroundingTiles(this);
            Console.SetOut(standardOutputFilter);
            Renderer.RenderLevel();
        }

        private void ExitLevel()
        {           
            this.successfulExitLevel = false;
            PlayerController.ResetPositionData(this);
            Console.Clear();
            this.successfulExitLevel = true;
        }
    }
}
 