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

        public MapController(Map map)
        {
            _map = map;
        }


        public void InitializeMap()
        {
            _map.Tiles = new Tile[_map.Size.Height, _map.Size.Width];

            for (uint row = 0; row < _map.Size.Height; row++)
            {
                for (uint column = 0; column < _map.Size.Width; column++)
                {
                    if (column == 0 || column == _map.Size.Width - 1 || row == 0 || row == _map.Size.Height - 1)
                    {
                        _map.Tiles[row, column] = new Tile(TileType.Wall, row, column);   //Set walls
                    }
                    else
                    {
                        _map.Tiles[row, column] = new Tile(TileType.Floor, row, column);   //Set the all remaining tiles to a floor
                    }
                }
            }
            _map.Tiles[1, 1].TileType = TileType.Player;
        }

        public string UpdateMap(TileType assignedTileType)
        {
            switch (assignedTileType)
            {
                case TileType.Wall:
                    return "#";
                case TileType.Floor:
                    return "-";
                case TileType.Key:
                    return "K";
                case TileType.Door:
                    return "D";
                case TileType.Monster:
                    return "M";
                case TileType.Player:
                    return "@";
                default:
                    throw new Exception($"Can't update {assignedTileType}.");
            }
        }
        public void Visualize()
        {
            Console.Write("\n\n");
            for (var row = 0; row < _map.Tiles.GetLength(0); row++)
            {
                for (var column = 0; column < _map.Tiles.GetLength(1); column++)
                {
                    Console.Write($"\t{_map.Tiles[row, column].Symbol = UpdateMap(_map.Tiles[row, column].TileType)}");
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
