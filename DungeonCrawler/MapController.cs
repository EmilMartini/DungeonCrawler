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
        private Player _player;

        public MapController(Map map, Player player)
        {
            _map = map;
            _player = player;
        }

        public void InitializeMap()
        {
            _map.Tiles = new Tile[_map.Size.Height, _map.Size.Width];

            for (int row = 0; row < _map.Size.Height; row++)
            {
                for (int column = 0; column < _map.Size.Width; column++)
                {
                    if (column == 0 || column == _map.Size.Width - 1 || row == 0 || row == _map.Size.Height - 1)
                    {
                        _map.Tiles[row, column] = new Wall(row, column);   //Set walls
                    }
                    else
                    {
                        _map.Tiles[row, column] = new Floor(row, column);   //Set floor
                    }
                }
            }
        }

        public void Render()
        {
            Console.Write("\n\n");
            for (var row = 0; row < _map.Tiles.GetLength(0); row++)
            {
                for (var column = 0; column < _map.Tiles.GetLength(1); column++)
                {
                    Console.Write($"\t{_map.Tiles[row, column].Graphic}");
                }

                if (row != _map.Tiles.GetLength(0) - 1)
                {
                    Console.Write("\n \n \n");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
