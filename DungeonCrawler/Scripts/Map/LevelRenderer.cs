using System;
using System.Threading;

namespace DungeonCrawler
{
    public class LevelRenderer
    {
        private readonly Level[] levels;
        private readonly Player player;
        public LevelRenderer(Level[] levels, Player player)
        {
            this.levels = levels;
            this.player = player;
        }
        public void RenderLevel(GameplayManager gameplayManager)
        {
            var currentLevel = levels[gameplayManager.CurrentLevel];
            RenderTilesAroundPlayer(currentLevel);
            RenderGameObjects(currentLevel);
            RenderPlayer();
            RenderUI(currentLevel);
        }
        void RenderTilesAroundPlayer(Level currentLevel)
        {
            for (int i = 0; i < player.SurroundingPoints.Length; i++)
            {
                Console.SetCursorPosition(player.SurroundingPoints[i].column + (player.SurroundingPoints[i].column + 2), player.SurroundingPoints[i].row);
                Console.ForegroundColor = currentLevel.Layout[player.SurroundingPoints[i].row, player.SurroundingPoints[i].column].Color;
                Console.Write(currentLevel.Layout[player.SurroundingPoints[i].row, player.SurroundingPoints[i].column].Graphic);
            }
        }
        void RenderGameObjects(Level currentLevel)
        {
            foreach (GameObject gameObject in currentLevel.ActiveGameObjects)
            {
                if(gameObject is Player)
                    continue;

                if (currentLevel.Layout[gameObject.Position.row, gameObject.Position.column].IsExplored == false)
                    continue;

                Console.SetCursorPosition(gameObject.Position.column + (gameObject.Position.column + 2), gameObject.Position.row);
                Console.ForegroundColor = gameObject.Color;
                Console.Write(gameObject.Graphic);
            }
            //Clear previous enemy positions from map
            if(currentLevel.PreviousEnemyPositions != null)
            {
                foreach (Point previousEnemyPosition in currentLevel.PreviousEnemyPositions)
                {
                    if (currentLevel.Layout[previousEnemyPosition.row, previousEnemyPosition.column].IsExplored)
                    {
                        Console.SetCursorPosition(previousEnemyPosition.column + (previousEnemyPosition.column + 2), previousEnemyPosition.row);
                        Console.ForegroundColor = currentLevel.Layout[previousEnemyPosition.row, previousEnemyPosition.column].Color;
                        Console.Write(currentLevel.Layout[previousEnemyPosition.row, previousEnemyPosition.column].Graphic);
                    }
                }
            }
        }
        void RenderPlayer()
        {
            Console.SetCursorPosition(player.Position.column + (player.Position.column + 2), player.Position.row);
            Console.ForegroundColor = player.Color;
            Console.Write(player.Graphic);
        }
        void RenderUI(Level currentLevel)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((currentLevel.Layout.GetLength(1) + 1) * 2, 2);
            Console.Write($"Number of moves:{player.NumberOfMoves}");

            Console.SetCursorPosition((currentLevel.Layout.GetLength(1) + 1) * 2, 3);
            Console.Write($"Enemies hit: {player.EnemiesInteractedWith}");

            Console.SetCursorPosition((currentLevel.Layout.GetLength(1) + 1) * 2, 4);
            Console.Write("Keys: ");
            Console.Write("\t\t");
            for (int i = 0; i < player.Inventory.KeyRing.Count; i++)
            {
                Console.SetCursorPosition((currentLevel.Layout.GetLength(1) + 4) * 2 + i, 4);
                Console.ForegroundColor = player.Inventory.KeyRing[i].Color;
                Console.Write($"{player.Inventory.KeyRing[i].Graphic}");
            }
        }
        public void RenderOuterWalls(GameplayManager gameplayManager)
        {
            var currentLevel = levels[gameplayManager.CurrentLevel];
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
        public void DisplayLevelInfo(GameplayManager gameplayManager)
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
