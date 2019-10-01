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
            this.levels = levels;
            this.player = player;
            this.stateMachine = stateMachine;
            stateMachine.PointsToRenderOnMap = new Point[8];
        }

        public void RenderLevel()
        {
            RenderTilesAroundPlayer();
            RenderGameObjects();
            RenderUI();
        }


        void RenderGameObjects()
        {
            foreach (GameObject gameObject in levels[(int)stateMachine.CurrentLevel].ActiveGameObjects)
            {
                if (levels[(int)stateMachine.CurrentLevel].ExploredLayout[gameObject.Position.row, gameObject.Position.column].IsExplored)
                {
                    Console.SetCursorPosition(gameObject.Position.column + (gameObject.Position.column + 2), gameObject.Position.row);
                    Console.ForegroundColor = gameObject.Color;
                    Console.Write(gameObject.Graphic);
                }
            }
        }

        //private void RenderEnemiesIfExplored()
        //{
        //    for (int i = 0; i < levels[(int)stateMachine.CurrentLevel].Enemies.Length; i++)
        //    {
        //        if (levels[(int)stateMachine.CurrentLevel].Enemies[i].IsExplored)
        //        {
        //            Console.ForegroundColor = levels[(int)stateMachine.CurrentLevel].Enemies[i].Color;
        //            Console.SetCursorPosition(levels[(int)stateMachine.CurrentLevel].Enemies[i].Position.column + (levels[(int)stateMachine.CurrentLevel].Enemies[i].Position.column + 2), levels[(int)stateMachine.CurrentLevel].Enemies[i].Position.row);
        //            Console.Write($"{levels[(int)stateMachine.CurrentLevel].ExploredLayout[levels[(int)stateMachine.CurrentLevel].Enemies[i].Position.row, levels[(int)stateMachine.CurrentLevel].Enemies[i].Position.column].Graphic}");
        //        }
        //
        //        if (levels[(int)stateMachine.CurrentLevel].PreviousEnemyPositions == null)
        //        {
        //            break;
        //        }
        //        else
        //        {
        //            Console.ForegroundColor = levels[(int)stateMachine.CurrentLevel].ExploredLayout[levels[(int)stateMachine.CurrentLevel].PreviousEnemyPositions[i].row, levels[(int)stateMachine.CurrentLevel].PreviousEnemyPositions[i].column].Color;
        //            Console.SetCursorPosition(levels[(int)stateMachine.CurrentLevel].PreviousEnemyPositions[i].column + (levels[(int)stateMachine.CurrentLevel].PreviousEnemyPositions[i].column + 2), levels[(int)stateMachine.CurrentLevel].PreviousEnemyPositions[i].row);
        //            if (levels[(int)stateMachine.CurrentLevel].ExploredLayout[levels[(int)stateMachine.CurrentLevel].PreviousEnemyPositions[i].row, levels[(int)stateMachine.CurrentLevel].PreviousEnemyPositions[i].column].IsExplored == true)
        //            {
        //                Console.Write($"{levels[(int)stateMachine.CurrentLevel].InitialLayout[levels[(int)stateMachine.CurrentLevel].PreviousEnemyPositions[i].row, levels[(int)stateMachine.CurrentLevel].PreviousEnemyPositions[i].column].Graphic}");
        //            }
        //            else
        //            {
        //                Console.Write(" ");
        //            }
        //        }
        //    }
        //}
        public void RenderTilesAroundPlayer()
        {
            for (int i = 0; i < stateMachine.PointsToRenderOnMap.Length; i++)
            {
                Console.SetCursorPosition(stateMachine.PointsToRenderOnMap[i].column + (stateMachine.PointsToRenderOnMap[i].column + 2), stateMachine.PointsToRenderOnMap[i].row);
                Console.ForegroundColor = stateMachine.Levels[(int)stateMachine.CurrentLevel].ExploredLayout[stateMachine.PointsToRenderOnMap[i].row, stateMachine.PointsToRenderOnMap[i].column].Color;
                Console.Write(stateMachine.Levels[(int)stateMachine.CurrentLevel].ExploredLayout[stateMachine.PointsToRenderOnMap[i].row, stateMachine.PointsToRenderOnMap[i].column].Graphic);
            }
        }
        private void RenderUI()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((levels[(int)stateMachine.CurrentLevel].InitialLayout.GetLength(1) + 1) * 2, 2);
            Console.Write($"Number of moves:{stateMachine.PlayerNumberOfMoves}");

            Console.SetCursorPosition((levels[(int)stateMachine.CurrentLevel].InitialLayout.GetLength(1) + 1) * 2, 3);
            Console.Write($"Enemies hit: {Player.EnemiesInteractedWith}");

            Console.SetCursorPosition((levels[(int)stateMachine.CurrentLevel].InitialLayout.GetLength(1) + 1) * 2, 4);
            Console.Write("Keys: ");
            Console.Write("\t\t");
            for (int i = 0; i < player.KeysInInventory.Count; i++)
            {
                Console.SetCursorPosition((levels[(int)stateMachine.CurrentLevel].InitialLayout.GetLength(1) + 4) * 2 + i, 4);
                Console.ForegroundColor = player.KeysInInventory[i].Color;
                Console.Write($"{player.KeysInInventory[i].Graphic}");
            }
        }
        public void RenderOuterWalls()
        {
            Console.Write("\n \n");
            for (int row = 0; row < levels[(int)stateMachine.CurrentLevel].InitialLayout.GetLength(0); row++)
            {
                for (int column = 0; column < levels[(int)stateMachine.CurrentLevel].InitialLayout.GetLength(1); column++)
                {
                    Console.SetCursorPosition(column + (column + 2), row);
                    Console.ForegroundColor = levels[(int)stateMachine.CurrentLevel].InitialLayout[row, column].Color;
                    if (levels[(int)stateMachine.CurrentLevel].InitialLayout[row, column].IsExplored == true)
                    {
                        Console.Write($"{levels[(int)stateMachine.CurrentLevel].InitialLayout[row, column].Graphic}");
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
