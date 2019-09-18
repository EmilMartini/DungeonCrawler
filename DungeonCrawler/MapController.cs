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
            _map.RenderedLayout = new Tile[_map.Size.Height, _map.Size.Width];

            for (int row = 0; row < _map.Size.Height; row++)
            {
                for (int column = 0; column < _map.Size.Width; column++)
                {
                    if (column == 0 || column == _map.Size.Width - 1 || row == 0 || row == _map.Size.Height - 1)
                    {
                        _map.InitialLayout[row, column] = new Wall();   //Set walls
                    }
                    else
                    {
                        _map.InitialLayout[row, column] = new Floor();   //Set floor
                    }
                }
            }
            Array.Copy(_map.InitialLayout, _map.RenderedLayout, _map.InitialLayout.Length);
            _map.RenderedLayout[setPlayerStart.X, setPlayerStart.Y] = _player;
        }

        public void RenderMap()
        {
            Console.Write("\n\n");
            for (var row = 0; row < _map.RenderedLayout.GetLength(0); row++)
            {
                for (var column = 0; column < _map.RenderedLayout.GetLength(1); column++)
                {
                    Console.Write($"\t{_map.RenderedLayout[row, column].Graphic}");
                }
                Console.Write("\n \n \n");
            }
        }
    }
}
