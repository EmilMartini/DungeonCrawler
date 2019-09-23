using System;
namespace DungeonCrawler
{
    public class LevelRenderer
    {
        private readonly Level level;
        private readonly Player player;
        private readonly Size consoleWindowSize = new Size(72, 36);
        public Point[] PointsToRender = new Point[8];
        public LevelRenderer(Level level, Player player)
        {
            this.level = level ?? throw new ArgumentNullException(nameof(level));
            this.player = player ?? throw new ArgumentNullException(nameof(player));
        }
        public void RenderLevel()
        {
            Point distanceBetweenTiles = new Point(((int)consoleWindowSize.Width / level.ExploredLayout.GetLength(0)), ((int)consoleWindowSize.Height / level.ExploredLayout.GetLength(1)));
            ExploreTilesAroundPlayer(player.Position);

            //Render tiles around player
            for (int i = 0; i < PointsToRender.Length; i++)
            {
                Console.ForegroundColor = level.ExploredLayout[PointsToRender[i].row, PointsToRender[i].column].Color;
                Console.SetCursorPosition(distanceBetweenTiles.row * PointsToRender[i].column, distanceBetweenTiles.column * PointsToRender[i].row);
                Console.Write($"{level.ExploredLayout[PointsToRender[i].row,PointsToRender[i].column].Graphic}");

                Console.ForegroundColor = level.ExploredLayout[player.Position.row, player.Position.column].Color;
                Console.SetCursorPosition(distanceBetweenTiles.row * player.Position.column, distanceBetweenTiles.column * player.Position.row);
                Console.Write($"{player.Graphic}");
            }

            //Render Enemies if explored
            for (int i = 0; i < level.Enemies.Length; i++)
            {
                if(level.Enemies[i].IsExplored)
                {
                    Console.ForegroundColor = level.Enemies[i].Color;
                    Console.SetCursorPosition(distanceBetweenTiles.row * level.Enemies[i].Position.column, distanceBetweenTiles.column * level.Enemies[i].Position.row);
                    Console.Write($"{level.ExploredLayout[level.Enemies[i].Position.row, level.Enemies[i].Position.column].Graphic}");
                }

                if(level.PreviousEnemyPositions == null)
                {
                    break;
                } else
                {
                    Console.ForegroundColor = level.ExploredLayout[level.PreviousEnemyPositions[i].row, level.PreviousEnemyPositions[i].column].Color;
                    Console.SetCursorPosition(distanceBetweenTiles.row * level.PreviousEnemyPositions[i].column, distanceBetweenTiles.column * level.PreviousEnemyPositions[i].row);
                    if (level.ExploredLayout[level.PreviousEnemyPositions[i].row, level.PreviousEnemyPositions[i].column].IsExplored == true)
                    {
                        Console.Write($"{level.InitialLayout[level.PreviousEnemyPositions[i].row, level.PreviousEnemyPositions[i].column].Graphic}");
                    } else
                    {
                        Console.Write("");
                    }
                }
            }

            //Render UI
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(distanceBetweenTiles.column * level.ExploredLayout.GetLength(0) * 2, distanceBetweenTiles.row * 1);
            Console.Write($"Number of moves: {player.NumberOfMoves}");

            Console.SetCursorPosition(distanceBetweenTiles.column * level.ExploredLayout.GetLength(0) * 2, distanceBetweenTiles.row * 2);
            Console.Write($"Enemies hit: {Player.EnemiesInteractedWith}");

            Console.SetCursorPosition(distanceBetweenTiles.column * level.ExploredLayout.GetLength(0) * 2, distanceBetweenTiles.row * 3);
            Console.Write("Keys: ");
            Console.Write("\t\t");
            for (int i = 0; i < Player.KeysInInventory.Count; i++)
            {         
                Console.SetCursorPosition((distanceBetweenTiles.column * level.ExploredLayout.GetLength(0) * 2) + (i + 5) + 2, distanceBetweenTiles.row * 3);
                Console.ForegroundColor = Player.KeysInInventory[i].Color;
                Console.Write($"{Player.KeysInInventory[i].Graphic}");
            }
        }
        public void ExploreTilesAroundPlayer(Point playerPosition)
        {   
            PointsToRender[0] = new Point(playerPosition.row, playerPosition.column - 1);
            PointsToRender[1] = new Point(playerPosition.row, playerPosition.column + 1);

            PointsToRender[2] = new Point(playerPosition.row - 1, playerPosition.column);
            PointsToRender[3] = new Point(playerPosition.row + 1, playerPosition.column);

            PointsToRender[4] = new Point(playerPosition.row + 1, playerPosition.column + 1);
            PointsToRender[5] = new Point(playerPosition.row - 1, playerPosition.column + 1);

            PointsToRender[6] = new Point(playerPosition.row - 1, playerPosition.column - 1);
            PointsToRender[7] = new Point(playerPosition.row + 1, playerPosition.column - 1);

            for (int i = 0; i < PointsToRender.Length; i++)
            {
                level.ExploredLayout[PointsToRender[i].row, PointsToRender[i].column].IsExplored = true;
            }
        }
        public void UpdatePlayerPosition(Point targetPosition)
        {
            level.ExploredLayout[player.Position.row, player.Position.column] = level.InitialLayout[player.Position.row, player.Position.column];
            player.Position = targetPosition;
            level.ExploredLayout[player.Position.row, player.Position.column] = player;
        }
        public void UpdateEnemyPositions(Enemy enemy, Point targetPosition, Point currentEnemyPosition, int index)
        {
            level.PreviousEnemyPositions[index] = currentEnemyPosition;
            level.ExploredLayout[enemy.Position.row, enemy.Position.column] = level.InitialLayout[enemy.Position.row, enemy.Position.column];
            enemy.Position = targetPosition;
            level.ExploredLayout[enemy.Position.row, enemy.Position.column] = enemy;
        }
    }
}
