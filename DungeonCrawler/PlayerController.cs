using System;


namespace DungeonCrawler
{
    public class PlayerController
    {
        private readonly Map _map;
        private readonly Player _player;

        public PlayerController(Map map, Player player)
        {
            _map = map ?? throw new ArgumentNullException(nameof(map));
            _player = player;
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
            Point currentLocation = GetPlayerPosition();
            Point targetLocation = new Point(currentLocation.X + directionVertical,
                                             currentLocation.Y + directionHorizontal);

            if (_map.Tiles[targetLocation.X, targetLocation.Y].TileType != TileType.Wall)
            {
                _map.Tiles[_player.Location.X, _player.Location.Y] = _map.InitialLayout[_player.Location.X, _player.Location.X];
                _player.Location = targetLocation;
                _map.Tiles[_player.Location.X, _player.Location.Y] = _player;
            }
        }
        public Point GetPlayerPosition()
        {
            return _player.Location;
        }

    }
}
