using System;
namespace DungeonCrawler
{
    public class MapController
    {
        private readonly Map map;
        private readonly Player player;
        private readonly Size consoleWindowSize = new Size(72, 36);

        public MapController(Map map, Player player)
        {
            this.map = map ?? throw new ArgumentNullException(nameof(map));
            this.player = player ?? throw new ArgumentNullException(nameof(player));
        }

        public void InitializeMap(Point setPlayerStart)
        {
            Console.SetWindowSize((int)consoleWindowSize.Width, (int)consoleWindowSize.Height);
            Console.SetBufferSize((int)consoleWindowSize.Width + 1, (int)consoleWindowSize.Height + 1);

            map.InitialLayout = new Tile[map.Size.Height, map.Size.Width];
            map.ExploredLayout = new Tile[map.Size.Height, map.Size.Width];

            for (int row = 0; row < map.Size.Height; row++)
            {
                for (int column = 0; column < map.Size.Width; column++)
                {
                    if (column == 0 || column == map.Size.Width - 1 || row == 0 || row == map.Size.Height - 1)
                    {
                        map.InitialLayout[row, column] = new Wall();
                    }
                    else
                    {
                        map.InitialLayout[row, column] = new Floor();
                    }
                }
            }
            Array.Copy(map.InitialLayout, map.ExploredLayout, map.InitialLayout.Length);
            map.ExploredLayout[setPlayerStart.row, setPlayerStart.column] = player;
        }

        public void DisplayInitialMap()
        {
            Console.Write("\n \n");
            for (int row = 0; row < map.ExploredLayout.GetLength(0); row++)
            {
                for (int column = 0; column < map.ExploredLayout.GetLength(1); column++)
                {
                    Console.SetCursorPosition(((int)consoleWindowSize.Width / map.ExploredLayout.GetLength(0) * column), ((int)consoleWindowSize.Height / map.ExploredLayout.GetLength(1) * row));
                    if (map.ExploredLayout[row, column].IsExplored == true)
                    {
                        Console.Write($"{map.ExploredLayout[row, column].Graphic}");
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
            Point cursorToPlayerPosition = new Point(((int)consoleWindowSize.Width / map.ExploredLayout.GetLength(0) * player.Position.column), ((int)consoleWindowSize.Height / map.ExploredLayout.GetLength(1) * player.Position.row));
            ExploreMap(player.Position);

            Console.SetCursorPosition(cursorToPlayerPosition.row, cursorToPlayerPosition.column );
            Console.Write($"{map.ExploredLayout[player.Position.row,player.Position.column].Graphic}");
            
        }
        public void ExploreMap(Point playerPosition)
        {
            for (int i = -1; i < 2; i++)
            {
                if (i != 0)
                {
                    map.ExploredLayout[playerPosition.row + 0, playerPosition.column + i].IsExplored = true; 
                }
                map.ExploredLayout[playerPosition.row + 1, playerPosition.column + i].IsExplored = true;
                map.ExploredLayout[playerPosition.row + -1, playerPosition.column + i].IsExplored = true;
            }
        }
        public void UpdatePlayerPosition(Point targetPosition)
        {
            map.ExploredLayout[player.Position.row, player.Position.column] = map.InitialLayout[player.Position.row, player.Position.column];
            player.Position = targetPosition;
            map.ExploredLayout[player.Position.row, player.Position.column] = player;
        }
    }
}
