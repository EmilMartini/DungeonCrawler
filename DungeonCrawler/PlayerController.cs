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
            _player = player ?? throw new ArgumentNullException(nameof(player));
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
            Point targetLocation = new Point(currentLocation.X + directionHorizontal,
                                             currentLocation.Y + directionVertical);

            if (_map.Tiles[targetLocation.X,targetLocation.Y].TileType != TileType.Wall)
            {
                _player.Location = targetLocation;
            }

        }
        public Point GetPlayerPosition()
        {
           return _player.Location;
        }
        
    }
}
