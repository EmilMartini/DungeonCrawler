using System;
using System.Threading;

namespace DungeonCrawler
{
    public class LevelRenderer
    {
        public static void RenderLevel(GameplayManager gameplayManager)
        {
            RenderTilesAroundPlayer(gameplayManager);
            RenderGameObjects(gameplayManager);
            RenderPlayer(gameplayManager);
            RenderUserInterface(gameplayManager);
        }

        public static void RenderOuterWalls(GameplayManager gameplayManager)
        {
            var currentLevel = gameplayManager.Levels[gameplayManager.CurrentLevel];
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

        public static void DisplayLevelInfo(GameplayManager gameplayManager)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine($"\n\n\n\n\n\n\n\t\t\t       Entering level {gameplayManager.CurrentLevel + 1}");
            Console.WriteLine("\t\t\t          Good Luck");
            Thread.Sleep(2500);
            GameplayManager.PlaySound("open-close-door");
            Console.Clear();
        }

        private static void RenderTilesAroundPlayer(GameplayManager gameplayManager)
        {
            foreach (Point currentPoint in gameplayManager.Player.SurroundingPoints)
            {
                var objectToPrint = gameplayManager.Levels[gameplayManager.CurrentLevel].Layout[currentPoint.Row, currentPoint.Column];
                Print(currentPoint, objectToPrint);
            }
        }

        private static void RenderGameObjects(GameplayManager gameplayManager)
        {
            foreach (var gameObject in gameplayManager.Levels[gameplayManager.CurrentLevel].ActiveGameObjects)
            {
                if (gameObject is Player)
                    continue;

                if (gameplayManager.Levels[gameplayManager.CurrentLevel]
                        .Layout[gameObject.Position.Row, gameObject.Position.Column].IsExplored == false)
                    continue;

                Print(gameObject.Position, gameObject);
            }
            ClearOldEnemyPositions(gameplayManager);
        }

        private static void ClearOldEnemyPositions(GameplayManager gameplayManager)
        {
            var tileAtPosition = gameplayManager.Levels[gameplayManager.CurrentLevel].Layout;
            if (gameplayManager.Levels[gameplayManager.CurrentLevel].PreviousEnemyPositions == null)
                return;

            foreach (var previousEnemyPosition in gameplayManager.Levels[gameplayManager.CurrentLevel]
                .PreviousEnemyPositions)
            {
                if (!tileAtPosition[previousEnemyPosition.Row, previousEnemyPosition.Column].IsExplored)
                    continue;

                Print(previousEnemyPosition, tileAtPosition[previousEnemyPosition.Row, previousEnemyPosition.Column]);
            }
        }

        private static void RenderPlayer(GameplayManager gameplayManager)
        {
            Print(gameplayManager.Player.Position, gameplayManager.Player);
        }

        private static void RenderUserInterface(GameplayManager gameplayManager)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(
                (gameplayManager.Levels[gameplayManager.CurrentLevel].Layout.GetLength(1) + 1) * 2, 2);
            Console.Write($"Number of moves:{gameplayManager.Player.NumberOfMoves}");

            Console.SetCursorPosition(
                (gameplayManager.Levels[gameplayManager.CurrentLevel].Layout.GetLength(1) + 1) * 2, 3);
            Console.Write($"Enemies hit: {gameplayManager.Player.EnemiesInteractedWith}");

            Console.SetCursorPosition(
                (gameplayManager.Levels[gameplayManager.CurrentLevel].Layout.GetLength(1) + 1) * 2, 4);
            Console.Write("Keys: ");
            Console.Write("\t\t");
            for (var i = 0; i < gameplayManager.Player.Inventory.KeyRing.Count; i++)
            {
                Console.SetCursorPosition(
                    (gameplayManager.Levels[gameplayManager.CurrentLevel].Layout.GetLength(1) + 4) * 2 + i, 4);
                Console.ForegroundColor = gameplayManager.Player.Inventory.KeyRing[i].Color;
                Console.Write($"{gameplayManager.Player.Inventory.KeyRing[i].Graphic}");
            }
        }

        private static void Print(Point objectPosition, Entity objectToPrint)
        {
            Console.SetCursorPosition(objectPosition.Column + (objectPosition.Column + 2), objectPosition.Row);
            Console.ForegroundColor = objectToPrint.Color;
            Console.Write(objectToPrint.Graphic);
        }
    }
}