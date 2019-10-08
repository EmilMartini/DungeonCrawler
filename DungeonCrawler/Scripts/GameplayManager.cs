using System;
using System.Collections.Generic;
using System.IO;
using System.Media;

namespace DungeonCrawler
{
    public class GameplayManager
    {
        bool successfulLoadLevel;
        bool succesfulExitLevel;
        bool succesfulDisplayScore;

        public void Init()
        {
            CurrentState = GameplayState.InitializeLevel;
        }

        /*Kolla så att allt som kan vara privat är det.
        För ni bjuder in alla som skall använda er kod att bryta encapsuleringen. Som man antar inte blir det i en klass.
        Och om vi av någon anledning inte använder oss av encapsulering så vill vi göra det.

        Det som kan vara helt privat bör vara det. t ex controllers i gameplaymanager

        Kolla över alla access modifiers.

        Man vill vara väldigt specifik med vad som skall kunna vara åtkomligt i en klass's instans. för att dependencies skall bli rätt. och inte (se nedan)

        Det är en dålig vana att slentrian mässigt göra en klass helt statisk, då ni inte kan specificera dependencies (paramterar) i en instansiering.
        Så, folk som använder eran kod. Kanske anroppar den statiska klassen, utan att den har blivit instansierad med sina dependencies. Vilket då blir
        körfel och buggar.*/
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

        public void RemoveGameObject(GameObject objectToRemove)
        {
            if (Levels[CurrentLevel].ActiveGameObjects.Contains(objectToRemove))
                Levels[CurrentLevel].ActiveGameObjects.Remove(objectToRemove);
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

        Renderer Renderer { get; set; } 
        GameplayState CurrentState { get; set; }
        public int CurrentLevel { get; private set; }
        public int NextLevel { get; set; }
        public List<Level> Levels { get; private set; }
        public Player Player { get; private set; }
        EnemyController EnemyController { get; set; }
        PlayerController PlayerController { get; set; }
        ConsoleOutputFilter ConsoleOutputFilter { get; set; }
        static SoundPlayer SoundPlayer { get; set; }

        void RunState()
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

        GameplayState CheckState(GameplayState currentState)
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
                    if (this.succesfulExitLevel && NextLevel != Levels.Count)
                    {
                        CurrentLevel = NextLevel;
                        return GameplayState.InitializeLevel;
                    }
                    else if (this.succesfulExitLevel && NextLevel >= Levels.Count)
                    {
                        return GameplayState.ShowScore;
                    }
                    else
                        return GameplayState.ExitLevel;

                case GameplayState.ShowScore:
                    return this.succesfulDisplayScore ? GameplayState.ExitGame : GameplayState.ShowScore;

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
                Console.Write(
                    $"\t\t\t       Final Score: {(Player.EnemiesInteractedWith * 20) + Player.NumberOfMoves}\n");

                Console.WriteLine("\n\n\n\t\t\t  Press any key to exit game...");
                Console.ReadKey();
                this.succesfulDisplayScore = true;
            }
            catch (Exception)
            {
                this.succesfulDisplayScore = false;
            }
        }

        void LoadCurrentLevel()
        {
            try
            {
                Renderer.RenderOuterWalls();
                PlayerController.ExploreSurroundingTiles(this);
                Renderer.RenderLevel();
                this.successfulLoadLevel = true;
            }
            catch (Exception)
            {
                this.successfulLoadLevel = false;
            }
        }

        void RunGame(TextWriter standardOutputFilter)
        {
            Console.SetOut(ConsoleOutputFilter);
            EnemyController.MoveEnemies(this);
            PlayerController.MovePlayer(PlayerController.GetInput(), this);
            PlayerController.ExploreSurroundingTiles(this);
            Console.SetOut(standardOutputFilter);
            Renderer.RenderLevel();
        }

        void ExitLevel()
        {
            try
            {
                PlayerController.ResetPositionData(this);
                Console.Clear();
                this.succesfulExitLevel = true;
            }
            catch (Exception)
            {
                this.succesfulExitLevel = false;
            }
        }
    }
}
 