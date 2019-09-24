﻿using System;
using System.Collections.Generic;

namespace DungeonCrawler
{
    public class LevelRenderer
    {
        private readonly Level[] levels;
        private readonly Player player;
        public Point[] PointsToRender = new Point[8];
        public LevelRenderer(Level[] levels, Player player)
        {
            this.levels = levels ?? throw new ArgumentNullException(nameof(levels));
            this.player = player ?? throw new ArgumentNullException(nameof(player));
        }
        public void RenderLevel()
        {
            RenderEnemiesIfExplored();
            ExploreTilesAroundPlayer(player.Position);
            RenderTilesAroundPlayer();
            RenderUI();
        }

        public void ExploreTilesAroundPlayer(Point playerPosition)
        {
            int index = 0;
            for (int row = (-1); row < 2; row++)
            {
                for (int column = (-1); column < 2; column++)
                {
                    if((row != 0 | column != 0))
                    {
                        PointsToRender[index] = new Point(playerPosition.row + row, playerPosition.column + column);
                        index++;
                    }
                }
            }

            for (int i = 0; i < PointsToRender.Length; i++)
            {
                levels[LevelLoader.CurrentLevel].ExploredLayout[PointsToRender[i].row, PointsToRender[i].column].IsExplored = true;
            }
        }
        private void RenderUI()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((levels[LevelLoader.CurrentLevel].InitialLayout.GetLength(1) + 1) * 2, 2);
            Console.Write($"Number of moves:{player.NumberOfMoves}");

            Console.SetCursorPosition((levels[LevelLoader.CurrentLevel].InitialLayout.GetLength(1) + 1) * 2, 3);
            Console.Write($"Enemies hit: {Player.EnemiesInteractedWith}");

            Console.SetCursorPosition((levels[LevelLoader.CurrentLevel].InitialLayout.GetLength(1) + 1) * 2, 4);
            Console.Write("Keys: ");
            Console.Write("\t\t");
            for (int i = 0; i < Player.KeysInInventory.Count; i++)
            {
                Console.SetCursorPosition((levels[LevelLoader.CurrentLevel].InitialLayout.GetLength(1) + 4) * 2 + i, 4);
                Console.ForegroundColor = Player.KeysInInventory[i].Color;
                Console.Write($"{Player.KeysInInventory[i].Graphic}");
            }
        }
        private void RenderEnemiesIfExplored()
        {
            for (int i = 0; i < levels[LevelLoader.CurrentLevel].Enemies.Length; i++)
            {
                if (levels[LevelLoader.CurrentLevel].Enemies[i].IsExplored)
                {
                    Console.ForegroundColor = levels[LevelLoader.CurrentLevel].Enemies[i].Color;
                    Console.SetCursorPosition(levels[LevelLoader.CurrentLevel].Enemies[i].Position.column + (levels[LevelLoader.CurrentLevel].Enemies[i].Position.column + 2), levels[LevelLoader.CurrentLevel].Enemies[i].Position.row);
                    Console.Write($"{levels[LevelLoader.CurrentLevel].ExploredLayout[levels[LevelLoader.CurrentLevel].Enemies[i].Position.row, levels[LevelLoader.CurrentLevel].Enemies[i].Position.column].Graphic}");
                }

                if (levels[LevelLoader.CurrentLevel].PreviousEnemyPositions == null)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = levels[LevelLoader.CurrentLevel].ExploredLayout[levels[LevelLoader.CurrentLevel].PreviousEnemyPositions[i].row, levels[LevelLoader.CurrentLevel].PreviousEnemyPositions[i].column].Color;
                    Console.SetCursorPosition(levels[LevelLoader.CurrentLevel].PreviousEnemyPositions[i].column + (levels[LevelLoader.CurrentLevel].PreviousEnemyPositions[i].column + 2), levels[LevelLoader.CurrentLevel].PreviousEnemyPositions[i].row);
                    if (levels[LevelLoader.CurrentLevel].ExploredLayout[levels[LevelLoader.CurrentLevel].PreviousEnemyPositions[i].row, levels[LevelLoader.CurrentLevel].PreviousEnemyPositions[i].column].IsExplored == true)
                    {
                        Console.Write($"{levels[LevelLoader.CurrentLevel].InitialLayout[levels[LevelLoader.CurrentLevel].PreviousEnemyPositions[i].row, levels[LevelLoader.CurrentLevel].PreviousEnemyPositions[i].column].Graphic}");
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
                Console.ForegroundColor = levels[LevelLoader.CurrentLevel].ExploredLayout[PointsToRender[i].row, PointsToRender[i].column].Color;
                Console.SetCursorPosition(PointsToRender[i].column + (PointsToRender[i].column + 2), PointsToRender[i].row);
                Console.Write($"{levels[LevelLoader.CurrentLevel].ExploredLayout[PointsToRender[i].row, PointsToRender[i].column].Graphic}");
            }
            Console.ForegroundColor = player.Color;
            Console.SetCursorPosition(player.Position.column + (player.Position.column + 2), player.Position.row);
            Console.Write($"{player.Graphic}");
        }
        public void UpdatePlayerPosition(Point targetPosition)
        {
            levels[LevelLoader.CurrentLevel].ExploredLayout[player.Position.row, player.Position.column] = levels[LevelLoader.CurrentLevel].InitialLayout[player.Position.row, player.Position.column];
            player.Position = targetPosition;
            levels[LevelLoader.CurrentLevel].ExploredLayout[player.Position.row, player.Position.column] = player;
        }
        public void UpdateEnemyPositions(Enemy enemy, Point targetPosition, Point currentEnemyPosition, int index)
        {
            levels[LevelLoader.CurrentLevel].PreviousEnemyPositions[index] = currentEnemyPosition;
            levels[LevelLoader.CurrentLevel].ExploredLayout[enemy.Position.row, enemy.Position.column] = levels[LevelLoader.CurrentLevel].InitialLayout[enemy.Position.row, enemy.Position.column];
            enemy.Position = targetPosition;
            levels[LevelLoader.CurrentLevel].ExploredLayout[enemy.Position.row, enemy.Position.column] = enemy;
        }
    }
}