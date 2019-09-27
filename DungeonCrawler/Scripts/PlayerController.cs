using DungeonCrawler.Keys;
using System;
namespace DungeonCrawler
{
    public class PlayerController
    {
        private readonly Level[] levels;
        private readonly LevelRenderer levelRenderer;
        private readonly Player player;
        private string outputString;

        public PlayerController(Level[] levels, Player player, LevelRenderer levelRenderer)
        {
            this.levels = levels ?? throw new ArgumentNullException(nameof(levels));
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
            if (levels[LevelLoader.CurrentLevel].InitialLayout[targetPosition.row, targetPosition.column] is IInteractable interactable)
            {
                bool interactionSucceded = interactable.Interact();
                if (interactionSucceded)
                {
                    levels[LevelLoader.CurrentLevel].InitialLayout[targetPosition.row, targetPosition.column] = new Floor();
                }
                else
                {
                    return;
                }
            }
            if (levels[LevelLoader.CurrentLevel].InitialLayout[targetPosition.row, targetPosition.column].TileType != TileType.Wall)
            {
                UpdatePlayerPosition(targetPosition);
                player.NumberOfMoves++;  
            }
        }

        public void UpdatePlayerPosition(Point targetPosition)
        {
            levels[LevelLoader.CurrentLevel].ExploredLayout[player.Position.row, player.Position.column] = levels[LevelLoader.CurrentLevel].InitialLayout[player.Position.row, player.Position.column];
            player.Position = targetPosition;
            levels[LevelLoader.CurrentLevel].ExploredLayout[player.Position.row, player.Position.column] = player;
        }
        public void ExploreTilesAroundPlayer(Point playerPosition)
        {
            int index = 0;
            for (int row = (-1); row < 2; row++)
            {
                for (int column = (-1); column < 2; column++)
                {
                    if ((row != 0 | column != 0))
                    {
                        levelRenderer.PointsToRender[index] = new Point(playerPosition.row + row, playerPosition.column + column);
                        index++;
                    }
                }
            }

            for (int i = 0; i < levelRenderer.PointsToRender.Length; i++)
            {
                levels[LevelLoader.CurrentLevel].ExploredLayout[levelRenderer.PointsToRender[i].row, levelRenderer.PointsToRender[i].column].IsExplored = true;
            }
        }
        public string OutputString
        {
            get { return outputString; }
            set { outputString = value; }
        }
    }
}
