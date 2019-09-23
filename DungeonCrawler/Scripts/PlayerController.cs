using DungeonCrawler.Keys;
using System;
namespace DungeonCrawler
{
    public class PlayerController
    {
        private readonly Level level;
        private readonly LevelRenderer levelRenderer;
        private readonly Player player;
        private string outputString;
        private Key[] inventory = new Key[4];

        public PlayerController(Level level, Player player, LevelRenderer levelRenderer)
        {
            this.level = level ?? throw new ArgumentNullException(nameof(level));
            this.player = player ?? throw new ArgumentNullException(nameof(player));
            this.levelRenderer = levelRenderer ?? throw new ArgumentNullException(nameof(levelRenderer));
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
            if (level.InitialLayout[targetPosition.row, targetPosition.column] is IInteractable)
            {
                IInteractable interactable;
            }
            if (level.InitialLayout[targetPosition.row, targetPosition.column].TileType != TileType.Wall)
            {
                levelRenderer.UpdatePlayerPosition(targetPosition);
                player.NumberOfMoves++;
            }
        }

        public string OutputString
        {
            get { return outputString; }
            set { outputString = value; }
        }
        public Key[] Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }
    }
}
