using DungeonCrawler.Keys;
using System;
namespace DungeonCrawler
{
    public class PlayerController
    {
        private StateMachine stateMachine;
        private readonly Level[] levels;
        private readonly Player player;

        public PlayerController(Level[] levels, Player player, LevelRenderer levelRenderer, StateMachine stateMachine)
        {
            this.levels = levels;
            this.player = player;
            this.stateMachine = stateMachine;
            stateMachine.PlayerPosition = player.Position;
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
            stateMachine.PlayerPosition = player.Position;
            stateMachine.TargetPlayerPosition = new Point(stateMachine.PlayerPosition.row + directionRow,
                                                          stateMachine.PlayerPosition.column + directionColumn);
            if (levels[(int)stateMachine.LevelIndex].InitialLayout[stateMachine.TargetPlayerPosition.row, stateMachine.TargetPlayerPosition.column] is IInteractable interactable)
            {
                bool interactionSucceded = interactable.Interact();
                if (interactionSucceded)
                {
                    levels[(int)stateMachine.LevelIndex].InitialLayout[stateMachine.TargetPlayerPosition.row, stateMachine.TargetPlayerPosition.column] = new Floor();
                }
                else
                {
                    return;
                }
            }
            if (levels[(int)stateMachine.LevelIndex].InitialLayout[stateMachine.TargetPlayerPosition.row, stateMachine.TargetPlayerPosition.column].TileType != TileType.Wall)
            {
                UpdatePlayerPosition();
                stateMachine.PlayerNumberOfMoves++;  
            }
        }
        public void UpdatePlayerPosition()
        {
            levels[(int)stateMachine.LevelIndex].ExploredLayout[stateMachine.PlayerPosition.row, stateMachine.PlayerPosition.column] = levels[(int)stateMachine.LevelIndex].InitialLayout[stateMachine.PlayerPosition.row, stateMachine.PlayerPosition.column];
            stateMachine.PlayerPosition = stateMachine.TargetPlayerPosition;
            levels[(int)stateMachine.LevelIndex].ExploredLayout[stateMachine.PlayerPosition.row, stateMachine.PlayerPosition.column] = player;
            player.Position = stateMachine.PlayerPosition;
        }
        public void ExploreTilesAroundPlayer()
        {
            int index = 0;
            for (int row = (-1); row < 2; row++)
            {
                for (int column = (-1); column < 2; column++)
                {
                    if ((row != 0 | column != 0))
                    {
                        stateMachine.PointsToRenderOnMap[index] = new Point(stateMachine.PlayerPosition.row + row, stateMachine.PlayerPosition.column + column);
                        index++;
                    }
                }
            }
            for (int i = 0; i < stateMachine.PointsToRenderOnMap.Length; i++)
            {
                levels[(int)stateMachine.LevelIndex].ExploredLayout[stateMachine.PointsToRenderOnMap[i].row, stateMachine.PointsToRenderOnMap[i].column].IsExplored = true;
            }
        }
    }
}
