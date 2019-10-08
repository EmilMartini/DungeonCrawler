using System;
using System.Threading;

namespace DungeonCrawler
{
    public class Renderer
    {
        public Renderer(GameplayManager gameplayManager)
        {
            GameplayManager = gameplayManager;
        }
        GameplayManager GameplayManager { get; set; }

        public void RenderLevel()
        {
            RenderTilesAroundPlayer();
            RenderGameObjects();
            RenderPlayer();
            RenderUserInterface();
        }
        public void RenderOuterWalls()
        {
            var currentLevel = GameplayManager.Levels[GameplayManager.CurrentLevel];
            Console.Write("\n \n");
            for (var row = 0; row < currentLevel.Layout.GetLength(0); row++)
            {
                for (var column = 0; column < currentLevel.Layout.GetLength(1); column++)
                {
                    if (!currentLevel.Layout[row, column].IsExplored)
                        continue;

                    Print(new Point(row, column), currentLevel.Layout[row, column]);
                }
            }
        }
        public void DisplayLevelInfo()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine($"\n\n\n\n\n\n\n\t\t\t       Entering level {GameplayManager.CurrentLevel + 1}");
            Console.WriteLine("\t\t\t          Good Luck");
            Thread.Sleep(2500);
            Console.Clear();
        }
        void RenderTilesAroundPlayer()
        {
            foreach (Point currentPoint in GameplayManager.Player.SurroundingPoints)
            {
                var objectToPrint = GameplayManager.Levels[GameplayManager.CurrentLevel].Layout[currentPoint.Row, currentPoint.Column];
                Print(currentPoint, objectToPrint);
            }
        }
        void RenderGameObjects()
        {
            foreach (var gameObject in GameplayManager.Levels[GameplayManager.CurrentLevel].ActiveGameObjects)
            {
                if (gameObject is Player)
                    continue;

                if (!GameplayManager.Levels[GameplayManager.CurrentLevel]
                    .Layout[gameObject.Position.Row, gameObject.Position.Column].IsExplored)
                    continue;

                Print(gameObject.Position, gameObject);
            }
            ClearOldEnemyPositions();
        }
        void ClearOldEnemyPositions()
        {
            var tileAtPosition = GameplayManager.Levels[GameplayManager.CurrentLevel].Layout;
            if (GameplayManager.Levels[GameplayManager.CurrentLevel].PreviousEnemyPositions == null)
                return;

            foreach (var previousEnemyPosition in GameplayManager.Levels[GameplayManager.CurrentLevel]
                .PreviousEnemyPositions)
            {
                if (!tileAtPosition[previousEnemyPosition.Row, previousEnemyPosition.Column].IsExplored)
                    continue;

                Print(previousEnemyPosition, tileAtPosition[previousEnemyPosition.Row, previousEnemyPosition.Column]);
            }
        }
        void RenderPlayer()
        {
            Print(GameplayManager.Player.Position, GameplayManager.Player);
        }
        void RenderUserInterface()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(
                (GameplayManager.Levels[GameplayManager.CurrentLevel].Layout.GetLength(1) + 1) * 2, 2);
            Console.Write($"Number of moves:{GameplayManager.Player.NumberOfMoves}");

            Console.SetCursorPosition(
                (GameplayManager.Levels[GameplayManager.CurrentLevel].Layout.GetLength(1) + 1) * 2, 3);
            Console.Write($"Enemies hit: {GameplayManager.Player.EnemiesInteractedWith}");

            Console.SetCursorPosition(
                (GameplayManager.Levels[GameplayManager.CurrentLevel].Layout.GetLength(1) + 1) * 2, 4);
            Console.Write("Keys: ");
            Console.Write("\t\t");
            for (var i = 0; i < GameplayManager.Player.KeyRing.Count; i++)
            {
                Console.SetCursorPosition(
                    (GameplayManager.Levels[GameplayManager.CurrentLevel].Layout.GetLength(1) + 4) * 2 + i, 4);
                Console.ForegroundColor = GameplayManager.Player.KeyRing[i].Color;
                Console.Write($"{GameplayManager.Player.KeyRing[i].Graphic}");
            }
        }
        void Print(Point objectPosition, Entity objectToPrint)
        {
            Console.SetCursorPosition(objectPosition.Column + (objectPosition.Column + 2), objectPosition.Row);
            Console.ForegroundColor = objectToPrint.Color;
            Console.Write(objectToPrint.Graphic);
        }
    }
}