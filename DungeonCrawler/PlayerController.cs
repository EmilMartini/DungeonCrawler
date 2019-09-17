using System;


namespace DungeonCrawler
{
    public class PlayerController
    {
        private readonly Map _map;

        public PlayerController(Map map)
        {
            _map = map ?? throw new ArgumentNullException(nameof(map));
        }

        public void CheckInput()
        {
            var input = Console.ReadKey();

            switch(input.KeyChar)
            {
                case 'w':
                    MovePlayer(0, -1);
                    break;
                case 'a':
                    MovePlayer(-1, 0);
                    break;
                case 's':
                    MovePlayer(0, 1);
                    break;
                case 'd':
                    MovePlayer(1, 0);
                    break;
                default:
                    break;
            }

        }

        public void MovePlayer(int directionHorizontal, int directionVertical)
        {
            var currentPlayerPositionVertical = GetPlayerPositionVertical();
            var currentPlayerPositionHorizontal = GetPlayerPositionHorizontal();

            if(_map.Tiles[currentPlayerPositionVertical + directionVertical, currentPlayerPositionHorizontal + directionHorizontal].TileType != TileType.Wall)
            {
                TileType temp = _map.Tiles[currentPlayerPositionVertical + directionVertical, currentPlayerPositionHorizontal + directionHorizontal].TileType;
                _map.Tiles[currentPlayerPositionVertical + directionVertical, currentPlayerPositionHorizontal + directionHorizontal].TileType = TileType.Player;
                _map.Tiles[currentPlayerPositionVertical, currentPlayerPositionHorizontal].TileType = temp;
            }
            
        }

        private int GetPlayerPositionVertical()
        {
            for (var row = 0; row < _map.Tiles.GetLength(0); row++)
            {
                for (var column = 0; column < _map.Tiles.GetLength(1); column++)
                {
                    if (_map.Tiles[row, column].TileType == TileType.Player)
                        return row;
                }
            }
            throw new Exception("Can't find player.");
        }

        private int GetPlayerPositionHorizontal()
        {
            for (var row = 0; row < _map.Tiles.GetLength(0); row++)
            {
                for (var column = 0; column < _map.Tiles.GetLength(1); column++)
                {
                    if (_map.Tiles[row, column].TileType == TileType.Player)
                        return column;
                }
            }
            throw new Exception("Can't find player.");
        }

    }
}
