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
                    Console.SetCursorPosition(column + (column + 2), row);
                    Console.ForegroundColor = currentLevel.Layout[row, column].Color;
                    if (!currentLevel.Layout[row, column].IsExplored)
                        continue;

                    else
                    Console.Write($"{currentLevel.Layout[row, column].Graphic}");
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
            for (var i = 0; i < gameplayManager.Player.SurroundingPoints.Length; i++)
            {
                Console.SetCursorPosition(
                    gameplayManager.Player.SurroundingPoints[i].Column +
                    (gameplayManager.Player.SurroundingPoints[i].Column + 2),
                    gameplayManager.Player.SurroundingPoints[i].Row);
                Console.ForegroundColor = gameplayManager.Levels[gameplayManager.CurrentLevel]
                    .Layout[gameplayManager.Player.SurroundingPoints[i].Row,
                        gameplayManager.Player.SurroundingPoints[i].Column].Color;
                Console.Write(gameplayManager.Levels[gameplayManager.CurrentLevel]
                    .Layout[gameplayManager.Player.SurroundingPoints[i].Row,
                        gameplayManager.Player.SurroundingPoints[i].Column].Graphic);
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

                Console.SetCursorPosition(gameObject.Position.Column + (gameObject.Position.Column + 2),
                    gameObject.Position.Row);
                Console.ForegroundColor = gameObject.Color;
                Console.Write(gameObject.Graphic);
            }

            ClearOldEnemyPositions(gameplayManager);
        }

        private static void ClearOldEnemyPositions(GameplayManager gameplayManager)
        {
            if (gameplayManager.Levels[gameplayManager.CurrentLevel].PreviousEnemyPositions == null)
                return;

            foreach (var previousEnemyPosition in gameplayManager.Levels[gameplayManager.CurrentLevel]
                .PreviousEnemyPositions)
            {
                if (gameplayManager.Levels[gameplayManager.CurrentLevel]
                        .Layout[previousEnemyPosition.Row, previousEnemyPosition.Column].IsExplored == false)
                    continue;

                Console.SetCursorPosition(previousEnemyPosition.Column + (previousEnemyPosition.Column + 2),
                    previousEnemyPosition.Row);
                Console.ForegroundColor = gameplayManager.Levels[gameplayManager.CurrentLevel]
                    .Layout[previousEnemyPosition.Row, previousEnemyPosition.Column].Color;
                Console.Write(gameplayManager.Levels[gameplayManager.CurrentLevel]
                    .Layout[previousEnemyPosition.Row, previousEnemyPosition.Column].Graphic);
            }
        }

        private static void RenderPlayer(GameplayManager gameplayManager)
        {
            Console.SetCursorPosition(
                gameplayManager.Player.Position.Column + (gameplayManager.Player.Position.Column + 2),
                gameplayManager.Player.Position.Row);
            Console.ForegroundColor = gameplayManager.Player.Color;
            Console.Write(gameplayManager.Player.Graphic);
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
    }
}