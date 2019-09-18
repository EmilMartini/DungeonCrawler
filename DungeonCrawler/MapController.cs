using System;
namespace DungeonCrawler
{
    public class MapController
    {
        private readonly Map map;
        private readonly Player player;

        public MapController(Map map, Player player)
        {
            this.map = map;
            this.player = player;
        }

        public void InitializeMap(Point setPlayerStart)
        {
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

        public void RenderMap()
        {
            ExploreMap(player.Position);

            Console.Write("\n\n");
            for (var row = 0; row < map.ExploredLayout.GetLength(0); row++)
            {
                for (var column = 0; column < map.ExploredLayout.GetLength(1); column++)
                {
                    if(map.ExploredLayout[row, column].isExplored == true)
                    {
                        Console.Write($"   {map.ExploredLayout[row, column].Graphic}");
                    } else
                    {
                        Console.Write($"    ");
                    }
                }
                Console.Write("\n \n");
            }
        }

        public void ExploreMap(Point playerPosition)
        {
            for (int i = -1; i < 2; i++)
            {
                if (i != 0)
                {
                    map.ExploredLayout[playerPosition.row + 0, playerPosition.column + i].isExplored = true; 
                }
                map.ExploredLayout[playerPosition.row + 1, playerPosition.column + i].isExplored = true;
                map.ExploredLayout[playerPosition.row + -1, playerPosition.column + i].isExplored = true;
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
