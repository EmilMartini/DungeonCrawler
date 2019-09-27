using System;
using System.Collections.Generic;

namespace DungeonCrawler
{
    public class LevelRenderer
    {
        private StateMachine stateMachine;
        private readonly Level[] levels;
        private readonly Player player;
        public LevelRenderer(Level[] levels, Player player, StateMachine stateMachine)
        {
            this.levels = levels ?? throw new ArgumentNullException(nameof(levels));
            this.player = player ?? throw new ArgumentNullException(nameof(player));
            this.stateMachine = stateMachine;
            stateMachine.PointsToRenderOnMap = new Point[8];
        }

        /*
        //
        //TODO har flera lager med rendering, spara ner i en och samma aray, första lagret(walls, golv), andra lagret (keys, doors), tredje lager (enemies, player), fjärde lager (isExplored).
        //
        */

        public void RenderLevel()
        {
            RenderEnemiesIfExplored();
            RenderTilesAroundPlayer();
            RenderUI();
        }
        private void RenderUI()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((levels[(int)stateMachine.LevelIndex].InitialLayout.GetLength(1) + 1) * 2, 2);
            Console.Write($"Number of moves:{stateMachine.PlayerNumberOfMoves}");

            Console.SetCursorPosition((levels[(int)stateMachine.LevelIndex].InitialLayout.GetLength(1) + 1) * 2, 3);
            Console.Write($"Enemies hit: {Player.EnemiesInteractedWith}");

            Console.SetCursorPosition((levels[(int)stateMachine.LevelIndex].InitialLayout.GetLength(1) + 1) * 2, 4);
            Console.Write("Keys: ");
            Console.Write("\t\t");
            for (int i = 0; i < Player.KeysInInventory.Count; i++)
            {
                Console.SetCursorPosition((levels[(int)stateMachine.LevelIndex].InitialLayout.GetLength(1) + 4) * 2 + i, 4);
                Console.ForegroundColor = Player.KeysInInventory[i].Color;
                Console.Write($"{Player.KeysInInventory[i].Graphic}");
            }
        }
        private void RenderEnemiesIfExplored()
        {
            for (int i = 0; i < levels[(int)stateMachine.LevelIndex].Enemies.Length; i++)
            {
                if (levels[(int)stateMachine.LevelIndex].Enemies[i].IsExplored)
                {
                    Console.ForegroundColor = levels[(int)stateMachine.LevelIndex].Enemies[i].Color;
                    Console.SetCursorPosition(levels[(int)stateMachine.LevelIndex].Enemies[i].Position.column + (levels[(int)stateMachine.LevelIndex].Enemies[i].Position.column + 2), levels[(int)stateMachine.LevelIndex].Enemies[i].Position.row);
                    Console.Write($"{levels[(int)stateMachine.LevelIndex].ExploredLayout[levels[(int)stateMachine.LevelIndex].Enemies[i].Position.row, levels[(int)stateMachine.LevelIndex].Enemies[i].Position.column].Graphic}");
                }

                if (levels[(int)stateMachine.LevelIndex].PreviousEnemyPositions == null)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = levels[(int)stateMachine.LevelIndex].ExploredLayout[levels[(int)stateMachine.LevelIndex].PreviousEnemyPositions[i].row, levels[(int)stateMachine.LevelIndex].PreviousEnemyPositions[i].column].Color;
                    Console.SetCursorPosition(levels[(int)stateMachine.LevelIndex].PreviousEnemyPositions[i].column + (levels[(int)stateMachine.LevelIndex].PreviousEnemyPositions[i].column + 2), levels[(int)stateMachine.LevelIndex].PreviousEnemyPositions[i].row);
                    if (levels[(int)stateMachine.LevelIndex].ExploredLayout[levels[(int)stateMachine.LevelIndex].PreviousEnemyPositions[i].row, levels[(int)stateMachine.LevelIndex].PreviousEnemyPositions[i].column].IsExplored == true)
                    {
                        Console.Write($"{levels[(int)stateMachine.LevelIndex].InitialLayout[levels[(int)stateMachine.LevelIndex].PreviousEnemyPositions[i].row, levels[(int)stateMachine.LevelIndex].PreviousEnemyPositions[i].column].Graphic}");
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
            for (int i = 0; i < stateMachine.PointsToRenderOnMap.Length; i++)
            {
                Console.ForegroundColor = levels[(int)stateMachine.LevelIndex].ExploredLayout[stateMachine.PointsToRenderOnMap[i].row, stateMachine.PointsToRenderOnMap[i].column].Color;
                Console.SetCursorPosition(stateMachine.PointsToRenderOnMap[i].column + (stateMachine.PointsToRenderOnMap[i].column + 2), stateMachine.PointsToRenderOnMap[i].row);
                Console.Write($"{levels[(int)stateMachine.LevelIndex].ExploredLayout[stateMachine.PointsToRenderOnMap[i].row, stateMachine.PointsToRenderOnMap[i].column].Graphic}");
            }
            Console.ForegroundColor = player.Color;
            Console.SetCursorPosition(stateMachine.PlayerPosition.column + (stateMachine.PlayerPosition.column + 2), stateMachine.PlayerPosition.row);
            Console.Write($"{player.Graphic}");
        }
        public void RenderInitialExploredTiles()
        {
            Console.Write("\n \n");
            for (int row = 0; row < levels[(int)stateMachine.LevelIndex].InitialLayout.GetLength(0); row++)
            {
                for (int column = 0; column < levels[(int)stateMachine.LevelIndex].InitialLayout.GetLength(1); column++)
                {
                    Console.SetCursorPosition(column + (column + 2), row);
                    Console.ForegroundColor = levels[(int)stateMachine.LevelIndex].InitialLayout[row, column].Color;
                    if (levels[(int)stateMachine.LevelIndex].InitialLayout[row, column].IsExplored == true)
                    {
                        Console.Write($"{levels[(int)stateMachine.LevelIndex].InitialLayout[row, column].Graphic}");
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
