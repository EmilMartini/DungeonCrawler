using System;
namespace DungeonCrawler
{
    public class LevelRenderer
    {
        private readonly Level level;
        private readonly Player player;
        private readonly Size consoleWindowSize = new Size(72, 36);

        public Point[] pointsToRender = new Point[8];

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
            for (int i = 0; i < pointsToRender.Length; i++)
            {
                Console.ForegroundColor = level.ExploredLayout[pointsToRender[i].row, pointsToRender[i].column].Color;
                Console.SetCursorPosition(distanceBetweenTiles.row * pointsToRender[i].column, distanceBetweenTiles.column * pointsToRender[i].row);
                Console.Write($"{level.ExploredLayout[pointsToRender[i].row,pointsToRender[i].column].Graphic}");

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
            Console.Write($"Score: ");
        }

        public void ExploreTilesAroundPlayer(Point playerPosition)
        {   
            pointsToRender[0] = new Point(playerPosition.row, playerPosition.column - 1);
            pointsToRender[1] = new Point(playerPosition.row, playerPosition.column + 1);

            pointsToRender[2] = new Point(playerPosition.row - 1, playerPosition.column);
            pointsToRender[3] = new Point(playerPosition.row + 1, playerPosition.column);

            pointsToRender[4] = new Point(playerPosition.row + 1, playerPosition.column + 1);
            pointsToRender[5] = new Point(playerPosition.row - 1, playerPosition.column + 1);

            pointsToRender[6] = new Point(playerPosition.row - 1, playerPosition.column - 1);
            pointsToRender[7] = new Point(playerPosition.row + 1, playerPosition.column - 1);

            for (int i = 0; i < pointsToRender.Length; i++)
            {
                level.ExploredLayout[pointsToRender[i].row, pointsToRender[i].column].IsExplored = true;
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
