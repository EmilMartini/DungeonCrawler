using System;


namespace DungeonCrawler
{
    public class PlayerController
    {
        private readonly Map _map;
        private readonly MapController _mapController;
        private readonly Player _player;

        public PlayerController(Map map, Player player, MapController mapController)
        {
            _map = map ?? throw new ArgumentNullException(nameof(map));
            _player = player;
            _mapController = mapController;
        }

        public void CheckInput()
        {
            var input = Console.ReadKey();
            switch(input.KeyChar)
            {
                case 'w':
                    MovePlayer(-1, 0);
                    break;
                case 'a':
                    MovePlayer(0, -1);
                    break;
                case 's':
                    MovePlayer(1, 0);
                    break;
                case 'd':
                    MovePlayer(0, 1);
                    break;
                default:
                    break;
            }
        }
        public void MovePlayer(int directionRow, int directionColumn)
        {
            Point currentPosition = _player.Position;
            Point targetPosition = new Point(currentPosition.row + directionRow,
                                             currentPosition.column + directionColumn);

            if (_map.InitialLayout[targetPosition.row, targetPosition.column].TileType != TileType.Wall)
            {
                _mapController.UpdatePlayerPosition(targetPosition);
            }
        }
    }
}
