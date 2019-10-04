using System;
using System.Threading;

namespace DungeonCrawler
{
    public class LevelRenderer
    {
        public LevelRenderer()
        { 
        }
        public static void RenderLevel(GameplayManager gameplayManager)
        {
            RenderTilesAroundPlayer(gameplayManager);
            RenderGameObjects(gameplayManager);
            RenderPlayer(gameplayManager);
            RenderUI(gameplayManager);
        }
        static void RenderTilesAroundPlayer(GameplayManager gameplayManager)
        {
            for (int i = 0; i < gameplayManager.Player.SurroundingPoints.Length; i++)
            {
                Console.SetCursorPosition(gameplayManager.Player.SurroundingPoints[i].column + (gameplayManager.Player.SurroundingPoints[i].column + 2), gameplayManager.Player.SurroundingPoints[i].row);
                Console.ForegroundColor = gameplayManager.Levels[gameplayManager.CurrentLevel].Layout[gameplayManager.Player.SurroundingPoints[i].row, gameplayManager.Player.SurroundingPoints[i].column].Color;
                Console.Write(gameplayManager.Levels[gameplayManager.CurrentLevel].Layout[gameplayManager.Player.SurroundingPoints[i].row, gameplayManager.Player.SurroundingPoints[i].column].Graphic);
            }
        }
        static void RenderGameObjects(GameplayManager gameplayManager)
        {
            foreach (GameObject gameObject in gameplayManager.Levels[gameplayManager.CurrentLevel].ActiveGameObjects)
            {
                if(gameObject is Player)
                    continue;

                if (gameplayManager.Levels[gameplayManager.CurrentLevel].Layout[gameObject.Position.row, gameObject.Position.column].IsExplored == false)
                    continue;

                Console.SetCursorPosition(gameObject.Position.column + (gameObject.Position.column + 2), gameObject.Position.row);
                Console.ForegroundColor = gameObject.Color;
                Console.Write(gameObject.Graphic);
            }
            //Clear previous enemy positions from map
            if(gameplayManager.Levels[gameplayManager.CurrentLevel].PreviousEnemyPositions != null)
            {
                foreach (Point previousEnemyPosition in gameplayManager.Levels[gameplayManager.CurrentLevel].PreviousEnemyPositions)
                {
                    if (gameplayManager.Levels[gameplayManager.CurrentLevel].Layout[previousEnemyPosition.row, previousEnemyPosition.column].IsExplored == false)
                        continue;
                    
                    Console.SetCursorPosition(previousEnemyPosition.column + (previousEnemyPosition.column + 2), previousEnemyPosition.row);
                    Console.ForegroundColor = gameplayManager.Levels[gameplayManager.CurrentLevel].Layout[previousEnemyPosition.row, previousEnemyPosition.column].Color;
                    Console.Write(gameplayManager.Levels[gameplayManager.CurrentLevel].Layout[previousEnemyPosition.row, previousEnemyPosition.column].Graphic);
                    
                }
            }
        }
        static void RenderPlayer(GameplayManager gameplayManager)
        {
            Console.SetCursorPosition(gameplayManager.Player.Position.column + (gameplayManager.Player.Position.column + 2), gameplayManager.Player.Position.row);
            Console.ForegroundColor = gameplayManager.Player.Color;
            Console.Write(gameplayManager.Player.Graphic);
        }
        static void RenderUI(GameplayManager gameplayManager)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((gameplayManager.Levels[gameplayManager.CurrentLevel].Layout.GetLength(1) + 1) * 2, 2);
            Console.Write($"Number of moves:{gameplayManager.Player.NumberOfMoves}");

            Console.SetCursorPosition((gameplayManager.Levels[gameplayManager.CurrentLevel].Layout.GetLength(1) + 1) * 2, 3);
            Console.Write($"Enemies hit: {gameplayManager.Player.EnemiesInteractedWith}");

            Console.SetCursorPosition((gameplayManager.Levels[gameplayManager.CurrentLevel].Layout.GetLength(1) + 1) * 2, 4);
            Console.Write("Keys: ");
            Console.Write("\t\t");
            for (int i = 0; i < gameplayManager.Player.Inventory.KeyRing.Count; i++)
            {
                Console.SetCursorPosition((gameplayManager.Levels[gameplayManager.CurrentLevel].Layout.GetLength(1) + 4) * 2 + i, 4);
                Console.ForegroundColor = gameplayManager.Player.Inventory.KeyRing[i].Color;
                Console.Write($"{gameplayManager.Player.Inventory.KeyRing[i].Graphic}");
            }
        }
        public static void RenderOuterWalls(GameplayManager gameplayManager)
        {
            var currentLevel = gameplayManager.Levels[gameplayManager.CurrentLevel];
            Console.Write("\n \n");
            for (int row = 0; row < currentLevel.Layout.GetLength(0); row++)
            {
                for (int column = 0; column < currentLevel.Layout.GetLength(1); column++)
                {
                    Console.SetCursorPosition(column + (column + 2), row);
                    Console.ForegroundColor = currentLevel.Layout[row, column].Color;
                    if (currentLevel.Layout[row, column].IsExplored == true)
                    {
                        Console.Write($"{currentLevel.Layout[row, column].Graphic}");
                    }
                    else
                    {
                        Console.Write($"");
                    }
                }
                Console.Write("");
            }
        }
        public static void DisplayLevelInfo(GameplayManager gameplayManager)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine($"\n\n\n\n\n\n\n\t\t\t       Entering level {gameplayManager.CurrentLevel + 1}");
            Console.WriteLine($"\t\t\t          Good Luck");
            Thread.Sleep(2500);
            GameplayManager.PlaySound("open-close-door");
            Console.Clear();
        }
    }
}
