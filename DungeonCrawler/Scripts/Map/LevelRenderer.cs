using System;
using System.Collections.Generic;

namespace DungeonCrawler
{
    public class LevelRenderer
    {
        private readonly Level[] levels;
        private readonly Player player;
        private Point[] pointsToRender = new Point[8];
        public LevelRenderer(Level[] levels, Player player)
        {
            this.levels = levels ?? throw new ArgumentNullException(nameof(levels));
            this.player = player ?? throw new ArgumentNullException(nameof(player));
        }
        public void RenderLevel()
        {
            RenderEnemiesIfExplored();
            RenderTilesAroundPlayer();
            RenderUI();
        }
        private void RenderUI()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((levels[(int)LevelLoader.CurrentLevel].InitialLayout.GetLength(1) + 1) * 2, 2);
            Console.Write($"Number of moves:{player.NumberOfMoves}");

            Console.SetCursorPosition((levels[(int)LevelLoader.CurrentLevel].InitialLayout.GetLength(1) + 1) * 2, 3);
            Console.Write($"Enemies hit: {Player.EnemiesInteractedWith}");

            Console.SetCursorPosition((levels[(int)LevelLoader.CurrentLevel].InitialLayout.GetLength(1) + 1) * 2, 4);
            Console.Write("Keys: ");
            Console.Write("\t\t");
            for (int i = 0; i < Player.KeysInInventory.Count; i++)
            {
                Console.SetCursorPosition((levels[(int)LevelLoader.CurrentLevel].InitialLayout.GetLength(1) + 4) * 2 + i, 4);
                Console.ForegroundColor = Player.KeysInInventory[i].Color;
                Console.Write($"{Player.KeysInInventory[i].Graphic}");
            }
        }
        private void RenderEnemiesIfExplored()
        {
            for (int i = 0; i < levels[(int)LevelLoader.CurrentLevel].Enemies.Length; i++)
            {
                if (levels[(int)LevelLoader.CurrentLevel].Enemies[i].IsExplored)
                {
                    Console.ForegroundColor = levels[(int)LevelLoader.CurrentLevel].Enemies[i].Color;
                    Console.SetCursorPosition(levels[(int)LevelLoader.CurrentLevel].Enemies[i].Position.column + (levels[(int)LevelLoader.CurrentLevel].Enemies[i].Position.column + 2), levels[(int)LevelLoader.CurrentLevel].Enemies[i].Position.row);
                    Console.Write($"{levels[(int)LevelLoader.CurrentLevel].ExploredLayout[levels[(int)LevelLoader.CurrentLevel].Enemies[i].Position.row, levels[(int)LevelLoader.CurrentLevel].Enemies[i].Position.column].Graphic}");
                }

                if (levels[(int)LevelLoader.CurrentLevel].PreviousEnemyPositions == null)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = levels[(int)LevelLoader.CurrentLevel].ExploredLayout[levels[(int)LevelLoader.CurrentLevel].PreviousEnemyPositions[i].row, levels[(int)LevelLoader.CurrentLevel].PreviousEnemyPositions[i].column].Color;
                    Console.SetCursorPosition(levels[(int)LevelLoader.CurrentLevel].PreviousEnemyPositions[i].column + (levels[(int)LevelLoader.CurrentLevel].PreviousEnemyPositions[i].column + 2), levels[(int)LevelLoader.CurrentLevel].PreviousEnemyPositions[i].row);
                    if (levels[(int)LevelLoader.CurrentLevel].ExploredLayout[levels[(int)LevelLoader.CurrentLevel].PreviousEnemyPositions[i].row, levels[(int)LevelLoader.CurrentLevel].PreviousEnemyPositions[i].column].IsExplored == true)
                    {
                        Console.Write($"{levels[(int)LevelLoader.CurrentLevel].InitialLayout[levels[(int)LevelLoader.CurrentLevel].PreviousEnemyPositions[i].row, levels[(int)LevelLoader.CurrentLevel].PreviousEnemyPositions[i].column].Graphic}");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
        }
        private void RenderTilesAroundPlayer()
        {
            for (int i = 0; i < PointsToRender.Length; i++)
            {
                Console.ForegroundColor = levels[(int)LevelLoader.CurrentLevel].ExploredLayout[PointsToRender[i].row, PointsToRender[i].column].Color;
                Console.SetCursorPosition(PointsToRender[i].column + (PointsToRender[i].column + 2), PointsToRender[i].row);
                Console.Write($"{levels[(int)LevelLoader.CurrentLevel].ExploredLayout[PointsToRender[i].row, PointsToRender[i].column].Graphic}");
            }
            Console.ForegroundColor = player.Color;
            Console.SetCursorPosition(player.Position.column + (player.Position.column + 2), player.Position.row);
            Console.Write($"{player.Graphic}");
        }
        public void RenderInitialExploredTiles()
        {
            Console.Write("\n \n");
            for (int row = 0; row < levels[(int)LevelLoader.CurrentLevel].InitialLayout.GetLength(0); row++)
            {
                for (int column = 0; column < levels[(int)LevelLoader.CurrentLevel].InitialLayout.GetLength(1); column++)
                {
                    Console.SetCursorPosition(column + (column + 2), row);
                    Console.ForegroundColor = levels[(int)LevelLoader.CurrentLevel].InitialLayout[row, column].Color;
                    if (levels[(int)LevelLoader.CurrentLevel].InitialLayout[row, column].IsExplored == true)
                    {
                        Console.Write($"{levels[(int)LevelLoader.CurrentLevel].InitialLayout[row, column].Graphic}");
                    }
                    else
                    {
                        Console.Write($"");
                    }
                }
                Console.Write("");
            }
        }
        public Point[] PointsToRender
        {
            get { return pointsToRender; }
            set { pointsToRender = value; }
        }
    }
}
