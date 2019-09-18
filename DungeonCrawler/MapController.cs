using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class MapController
    {
        private readonly Map _map;
        private readonly Player _player;

        public MapController(Map map, Player player)
        {
            _map = map;
            _player = player;
        }

        public void InitializeMap(Point setPlayerStart)
        {
            _map.InitialLayout = new Tile[_map.Size.Height, _map.Size.Width];
            _map.ExploredLayout = new Tile[_map.Size.Height, _map.Size.Width];

            for (int row = 0; row < _map.Size.Height; row++)
            {
                for (int column = 0; column < _map.Size.Width; column++)
                {
                    if (column == 0 || column == _map.Size.Width - 1 || row == 0 || row == _map.Size.Height - 1)
                    {
                        _map.InitialLayout[row, column] = new Wall();
                    }
                    else
                    {
                        _map.InitialLayout[row, column] = new Floor();
                    }
                }
            }
            Array.Copy(_map.InitialLayout, _map.ExploredLayout, _map.InitialLayout.Length);
            _map.ExploredLayout[setPlayerStart.row, setPlayerStart.column] = _player;
        }

        public void RenderMap()
        {
            ExploreMap(_player.Position);

            Console.Write("\n\n");
            for (var row = 0; row < _map.ExploredLayout.GetLength(0); row++)
            {
                for (var column = 0; column < _map.ExploredLayout.GetLength(1); column++)
                {
                    if(_map.ExploredLayout[row, column].isExplored == true)
                    {
                        Console.Write($"   {_map.ExploredLayout[row, column].Graphic}");
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
                    _map.ExploredLayout[playerPosition.row + 0, playerPosition.column + i].isExplored = true; 
                }
                _map.ExploredLayout[playerPosition.row + 1, playerPosition.column + i].isExplored = true;
                _map.ExploredLayout[playerPosition.row + -1, playerPosition.column + i].isExplored = true;
            }
        }

        public void UpdatePlayerPosition(Point targetPosition)
        {
            _map.ExploredLayout[_player.Position.row, _player.Position.column] = _map.InitialLayout[_player.Position.row, _player.Position.row];
            _player.Position = targetPosition;
            _map.ExploredLayout[_player.Position.row, _player.Position.column] = _player;

        }
    }
}
