using System;
namespace DungeonCrawler
{
    public class LevelRenderer
    {
        private GameplayManager gameplayManager;
        private readonly Level[] levels;
        private readonly Player player;
        public LevelRenderer(Level[] levels, Player player, GameplayManager gameplayManager)
        {
            this.levels = levels;
            this.player = player;
            this.gameplayManager = gameplayManager;
            gameplayManager.PointsToRenderOnMap = new Point[8];
        }
        public void RenderLevel()
        {
            RenderTilesAroundPlayer();
            RenderGameObjects();
            RenderPlayer();
            RenderUI();
        }
        void RenderGameObjects()
        {
            foreach (GameObject gameObject in levels[(int)gameplayManager.CurrentLevel].ActiveGameObjects)
            {
                if(gameObject is Player)
                {
                    continue;
                } else
                {
                    if (levels[(int)gameplayManager.CurrentLevel].ExploredLayout[gameObject.Position.row, gameObject.Position.column].IsExplored)
                    {
                        Console.SetCursorPosition(gameObject.Position.column + (gameObject.Position.column + 2), gameObject.Position.row);
                        Console.ForegroundColor = gameObject.Color;
                        Console.Write(gameObject.Graphic);
                    }
                }
            }
            //Clear previous enemy positions from map
            if(gameplayManager.Levels[(int)gameplayManager.CurrentLevel].PreviousEnemyPositions != null)
            {
                foreach (Point previousEnemyPosition in gameplayManager.Levels[(int)gameplayManager.CurrentLevel].PreviousEnemyPositions)
                {
                    if (levels[(int)gameplayManager.CurrentLevel].ExploredLayout[previousEnemyPosition.row, previousEnemyPosition.column].IsExplored)
                    {
                        Console.SetCursorPosition(previousEnemyPosition.column + (previousEnemyPosition.column + 2), previousEnemyPosition.row);
                        Console.ForegroundColor = levels[(int)gameplayManager.CurrentLevel].ExploredLayout[previousEnemyPosition.row, previousEnemyPosition.column].Color;
                        Console.Write(levels[(int)gameplayManager.CurrentLevel].ExploredLayout[previousEnemyPosition.row, previousEnemyPosition.column].Graphic);
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
        void RenderUI()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((levels[(int)gameplayManager.CurrentLevel].InitialLayout.GetLength(1) + 1) * 2, 2);
            Console.Write($"Number of moves:{player.NumberOfMoves}");

            Console.SetCursorPosition((levels[(int)gameplayManager.CurrentLevel].InitialLayout.GetLength(1) + 1) * 2, 3);
            Console.Write($"Enemies hit: {player.EnemiesInteractedWith}");

            Console.SetCursorPosition((levels[(int)gameplayManager.CurrentLevel].InitialLayout.GetLength(1) + 1) * 2, 4);
            Console.Write("Keys: ");
            Console.Write("\t\t");
            for (int i = 0; i < player.KeysInInventory.Count; i++)
            {
                Console.SetCursorPosition((levels[(int)gameplayManager.CurrentLevel].InitialLayout.GetLength(1) + 4) * 2 + i, 4);
                Console.ForegroundColor = player.KeysInInventory[i].Color;
                Console.Write($"{player.KeysInInventory[i].Graphic}");
            }
        }
        public void RenderTilesAroundPlayer()
        {
            for (int i = 0; i < gameplayManager.PointsToRenderOnMap.Length; i++)
            {
                Console.SetCursorPosition(gameplayManager.PointsToRenderOnMap[i].column + (gameplayManager.PointsToRenderOnMap[i].column + 2), gameplayManager.PointsToRenderOnMap[i].row);
                Console.ForegroundColor = gameplayManager.Levels[(int)gameplayManager.CurrentLevel].ExploredLayout[gameplayManager.PointsToRenderOnMap[i].row, gameplayManager.PointsToRenderOnMap[i].column].Color;
                Console.Write(gameplayManager.Levels[(int)gameplayManager.CurrentLevel].ExploredLayout[gameplayManager.PointsToRenderOnMap[i].row, gameplayManager.PointsToRenderOnMap[i].column].Graphic);
            }
        }
        public void RenderOuterWalls()
        {
            Console.Write("\n \n");
            for (int row = 0; row < levels[(int)gameplayManager.CurrentLevel].InitialLayout.GetLength(0); row++)
            {
                for (int column = 0; column < levels[(int)gameplayManager.CurrentLevel].InitialLayout.GetLength(1); column++)
                {
                    Console.SetCursorPosition(column + (column + 2), row);
                    Console.ForegroundColor = levels[(int)gameplayManager.CurrentLevel].InitialLayout[row, column].Color;
                    if (levels[(int)gameplayManager.CurrentLevel].InitialLayout[row, column].IsExplored == true)
                    {
                        Console.Write($"{levels[(int)gameplayManager.CurrentLevel].InitialLayout[row, column].Graphic}");
                    }
                    else
                    {
                        Console.Write($"");
                    }
                }
                Console.Write("");
            }
        }
    }
}
