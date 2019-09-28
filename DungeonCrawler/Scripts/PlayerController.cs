using DungeonCrawler.Keys;
using System;
namespace DungeonCrawler
{
    public class PlayerController
    {
        private StateMachine stateMachine;
        private readonly Level[] levels;
        private readonly Player player;

        public PlayerController(Level[] levels, Player player, StateMachine stateMachine)
        {
            this.levels = levels;
            this.player = player;
            this.stateMachine = stateMachine;
            stateMachine.PlayerPosition = player.Position;
        }
        public Point GetInput()
        {
            var input = Console.ReadKey();
            switch (input.KeyChar)
            {
                case 'w':
                    return new Point(-1, 0);
                case 'a':
                    return new Point(0, -1);
                case 's':
                    return new Point(1, 0);
                case 'd':
                    return new Point(0, 1);
                default:
                    return new Point(0, 0);
            }
        }
        public void MovePlayer(Point direction)
        {
            stateMachine.PlayerPosition = player.Position;
            stateMachine.TargetPlayerPosition = new Point(stateMachine.PlayerPosition.row + direction.row, stateMachine.PlayerPosition.column + direction.column);
            if (levels[(int)stateMachine.LevelIndex].InitialLayout[stateMachine.TargetPlayerPosition.row, stateMachine.TargetPlayerPosition.column] is IInteractable interactable)
            {
                bool interactionSucceded = interactable.Interact();
                if (interactionSucceded)
                {
                    if(levels[(int)stateMachine.LevelIndex].InitialLayout[stateMachine.TargetPlayerPosition.row, stateMachine.TargetPlayerPosition.column].TileType != TileType.Door)
                    {
                        levels[(int)stateMachine.LevelIndex].InitialLayout[stateMachine.TargetPlayerPosition.row, stateMachine.TargetPlayerPosition.column] = new Floor();
                    }
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

        public void ResetPlayerData()
        {
            for (int i = 0; i < stateMachine.PointsToRenderOnMap.Length; i++)
            {
                stateMachine.PointsToRenderOnMap[i] = new Point(0, 0);
            }
            player.Position = levels[(int)stateMachine.NextLevel].PlayerStartingTile;
            stateMachine.PlayerPosition = player.Position;
        }
    }
}
