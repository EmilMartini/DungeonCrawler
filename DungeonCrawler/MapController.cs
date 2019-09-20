using System;
namespace DungeonCrawler
{
    public class MapController
    {
        private readonly Level level;
        private readonly Player player;
        private readonly Size consoleWindowSize = new Size(72, 36);


        public MapController(Level level, Player player)
        {
            this.level = level ?? throw new ArgumentNullException(nameof(level));
            this.player = player ?? throw new ArgumentNullException(nameof(player));
        }

        public Point[] pointsToRender = new Point[8];

        public void InitializeMap(Point setPlayerStart)
        {
            Console.SetWindowSize((int)consoleWindowSize.Width, (int)consoleWindowSize.Height);
            Console.SetBufferSize((int)consoleWindowSize.Width + 1, (int)consoleWindowSize.Height + 1);

            level.InitialLayout = new Tile[level.Size.Height, level.Size.Width];
            level.ExploredLayout = new Tile[level.Size.Height, level.Size.Width];

            for (int row = 0; row < level.Size.Height; row++)
            {
                for (int column = 0; column < level.Size.Width; column++)
                {
                    if (column == 0 || column == level.Size.Width - 1 || row == 0 || row == level.Size.Height - 1)
                    {
                        level.InitialLayout[row, column] = new Wall();
                    }
                    else
                    {
                        level.InitialLayout[row, column] = new Floor();
                    }
                }
            }
            Array.Copy(level.InitialLayout, level.ExploredLayout, level.InitialLayout.Length);
            level.ExploredLayout[setPlayerStart.row, setPlayerStart.column] = player;
        }

        public void DisplayInitialMap()
        {
            Console.Write("\n \n");
            for (int row = 0; row < level.ExploredLayout.GetLength(0); row++)
            {
                for (int column = 0; column < level.ExploredLayout.GetLength(1); column++)
                {
                    Console.SetCursorPosition(((int)consoleWindowSize.Width / level.ExploredLayout.GetLength(0) * column), ((int)consoleWindowSize.Height / level.ExploredLayout.GetLength(1) * row));
                    Console.ForegroundColor = level.ExploredLayout[row, column].Color;
                    if (level.ExploredLayout[row, column].IsExplored == true)
                    {
                        Console.Write($"{level.ExploredLayout[row, column].Graphic}");
                    }
                    else
                    {
                        Console.Write($" ");
                    }
                }
                Console.Write("\n \n");
            }
        }

        public void RenderMap()
        {
            Point distanceBetweenTiles = new Point(((int)consoleWindowSize.Width / level.ExploredLayout.GetLength(0)), ((int)consoleWindowSize.Height / level.ExploredLayout.GetLength(1)));
            GetPointsToExplore(player.Position);
            SetTilesToExplored(pointsToRender);

            for (int i = 0; i < pointsToRender.Length; i++)
            {
                Console.ForegroundColor = level.ExploredLayout[pointsToRender[i].row, pointsToRender[i].column].Color;
                Console.SetCursorPosition(distanceBetweenTiles.row * pointsToRender[i].column, distanceBetweenTiles.column * pointsToRender[i].row);
                Console.Write($"{level.ExploredLayout[pointsToRender[i].row,pointsToRender[i].column].Graphic}");

                Console.ForegroundColor = level.ExploredLayout[player.Position.row, player.Position.column].Color;
                Console.SetCursorPosition(distanceBetweenTiles.row * player.Position.column, distanceBetweenTiles.column * player.Position.row);
                Console.Write($"{player.Graphic}");
            }
        }

        private void SetTilesToExplored(Point[] pointsToRender)
        {
            for (int i = 0; i < pointsToRender.Length; i++)
            {
                level.ExploredLayout[pointsToRender[i].row, pointsToRender[i].column].IsExplored = true;
            }
        }

        public void GetPointsToExplore(Point playerPosition)
        {   
            pointsToRender[0] = new Point(playerPosition.row, playerPosition.column - 1);
            pointsToRender[1] = new Point(playerPosition.row, playerPosition.column + 1);

            pointsToRender[2] = new Point(playerPosition.row - 1, playerPosition.column);
            pointsToRender[3] = new Point(playerPosition.row + 1, playerPosition.column);

            pointsToRender[4] = new Point(playerPosition.row + 1, playerPosition.column + 1);
            pointsToRender[5] = new Point(playerPosition.row - 1, playerPosition.column + 1);

            pointsToRender[6] = new Point(playerPosition.row - 1, playerPosition.column - 1);
            pointsToRender[7] = new Point(playerPosition.row + 1, playerPosition.column - 1);
        }
        public void UpdatePlayerPosition(Point targetPosition)
        {
            level.ExploredLayout[player.Position.row, player.Position.column] = level.InitialLayout[player.Position.row, player.Position.column];
            player.Position = targetPosition;
            level.ExploredLayout[player.Position.row, player.Position.column] = player;
        }
    }
}
