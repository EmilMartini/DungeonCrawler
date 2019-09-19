using System;
namespace DungeonCrawler
{
    public class PlayerController
    {
        private readonly Level map;
        private readonly MapController mapController;
        private readonly Player player;
        public PlayerController(Level level, Player player, MapController mapController)
        {
            this.map = level ?? throw new ArgumentNullException(nameof(level));
            this.player = player ?? throw new ArgumentNullException(nameof(player));
            this.mapController = mapController ?? throw new ArgumentNullException(nameof(mapController));
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
            Point currentPosition = player.Position;
            Point targetPosition = new Point(currentPosition.row + directionRow,
                                             currentPosition.column + directionColumn);
            if (map.InitialLayout[targetPosition.row, targetPosition.column].TileType != TileType.Wall)
            {
                mapController.UpdatePlayerPosition(targetPosition);
            }
        }
    }
}
