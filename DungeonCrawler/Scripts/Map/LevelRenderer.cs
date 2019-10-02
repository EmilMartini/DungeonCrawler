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
            RenderPlayer();
            RenderUI();
        }

        void RenderGameObjects()
        {
            foreach (GameObject gameObject in levels[(int)stateMachine.CurrentLevel].ActiveGameObjects)
            {
                if(gameObject is Player)
                {
                    continue;
                } else
                {
                    if (levels[(int)stateMachine.CurrentLevel].ExploredLayout[gameObject.Position.row, gameObject.Position.column].IsExplored)
                    {
                        Console.SetCursorPosition(gameObject.Position.column + (gameObject.Position.column + 2), gameObject.Position.row);
                        Console.ForegroundColor = gameObject.Color;
                        Console.Write(gameObject.Graphic);
                    }
                }
            }

            //Clear previous enemy positions from map
            if(stateMachine.Levels[(int)stateMachine.CurrentLevel].PreviousEnemyPositions != null)
            {
                foreach (Point previousEnemyPosition in stateMachine.Levels[(int)stateMachine.CurrentLevel].PreviousEnemyPositions)
                {
                    if (levels[(int)stateMachine.CurrentLevel].ExploredLayout[previousEnemyPosition.row, previousEnemyPosition.column].IsExplored)
                    {
                        Console.SetCursorPosition(previousEnemyPosition.column + (previousEnemyPosition.column + 2), previousEnemyPosition.row);
                        Console.ForegroundColor = levels[(int)stateMachine.CurrentLevel].ExploredLayout[previousEnemyPosition.row, previousEnemyPosition.column].Color;
                        Console.Write(levels[(int)stateMachine.CurrentLevel].ExploredLayout[previousEnemyPosition.row, previousEnemyPosition.column].Graphic);
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
            Console.SetCursorPosition((levels[(int)stateMachine.CurrentLevel].InitialLayout.GetLength(1) + 1) * 2, 2);
            Console.Write($"Number of moves:{stateMachine.PlayerNumberOfMoves}");

            Console.SetCursorPosition((levels[(int)stateMachine.CurrentLevel].InitialLayout.GetLength(1) + 1) * 2, 3);
            Console.Write($"Enemies hit: {player.EnemiesInteractedWith}");

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
        public void RenderTilesAroundPlayer()
        {
            for (int i = 0; i < stateMachine.PointsToRenderOnMap.Length; i++)
            {
                Console.SetCursorPosition(stateMachine.PointsToRenderOnMap[i].column + (stateMachine.PointsToRenderOnMap[i].column + 2), stateMachine.PointsToRenderOnMap[i].row);
                Console.ForegroundColor = stateMachine.Levels[(int)stateMachine.CurrentLevel].ExploredLayout[stateMachine.PointsToRenderOnMap[i].row, stateMachine.PointsToRenderOnMap[i].column].Color;
                Console.Write(stateMachine.Levels[(int)stateMachine.CurrentLevel].ExploredLayout[stateMachine.PointsToRenderOnMap[i].row, stateMachine.PointsToRenderOnMap[i].column].Graphic);
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
