using DungeonCrawler.Keys;
using System;
namespace DungeonCrawler
{
    public class PlayerController
    {
        private StateMachine stateMachine;
        private readonly Level[] levels;
        private readonly Player player;

        public PlayerController(Player player, StateMachine stateMachine)
        {
            this.player = player;
            this.levels = stateMachine.Levels;
            this.stateMachine = stateMachine;
            stateMachine.PlayerPosition = player.Position;
            stateMachine.Levels[(int)stateMachine.CurrentLevel].ActiveGameObjects.Add(player);
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
            if(!direction.Equals(new Point(0,0)))
            {
                player.TargetPosition = new Point(player.Position.row + direction.row, player.Position.column + direction.column);
                if (!(levels[(int)stateMachine.CurrentLevel].InitialLayout[player.TargetPosition.row, player.TargetPosition.column] is Wall))
                {
                    CheckInteraction(player.TargetPosition);
                    UpdatePlayerPosition();
                    stateMachine.PlayerNumberOfMoves++;  
                }
                
            }
            //if (levels[(int)stateMachine.CurrentLevel].InitialLayout[stateMachine.TargetPlayerPosition.row, stateMachine.TargetPlayerPosition.column] is IInteractable interactable)
            //{
            //    if (interactable.Interact())
            //    {
            //        if(!(interactable is Door))
            //        {                 
            //            levels[(int)stateMachine.CurrentLevel].InitialLayout[stateMachine.TargetPlayerPosition.row, stateMachine.TargetPlayerPosition.column] = new Floor();
            //        }
            //        else if(interactable is YellowDoor door && door.IsUnlocked)
            //        {
            //            stateMachine.NextLevel = door.NextLevel;
            //            stateMachine.Levels[(int)stateMachine.CurrentLevel].PlayerPositionWhenExit = stateMachine.PlayerPosition;
            //            stateMachine.CurrentState = StateMachine.State.ExitLevel;
            //        } else if(interactable is ExitDoor)
            //        {
            //            stateMachine.CurrentState = StateMachine.State.ExitGame;
            //        }
            //    } else if (interactable is Door door)
            //    {
            //        if (canUnlock(door));
            //    } else
            //    {
            //        return;
            //    }
            //}
        }

        private void CheckInteraction(Point targetPosition)
        {
            foreach (GameObject gameObject in stateMachine.Levels[(int)stateMachine.CurrentLevel].ActiveGameObjects)
            {
                if (gameObject is Player)
                {
                    continue;
                }
                else if (gameObject.Position.Equals(targetPosition) && gameObject is IInteractable interactable)
                {
                    interactable.Interact();
                    if(interactable is Key key)
                    {
                        stateMachine.Levels[(int)stateMachine.CurrentLevel].ActiveGameObjects.Remove(key);
                        break;
                    }
                }
            }
        }

        private bool canUnlock(Door door)
        {
            for (int i = 0; i < Player.KeysInInventory.Count; i++)
            {
                if (Player.KeysInInventory[i].Unlock.Equals((door.Unlock)))
                {
                    Player.KeysInInventory[i].NumberOfUses--;
                    if (Player.KeysInInventory[i].NumberOfUses <= 0)
                    {
                        Player.KeysInInventory.RemoveAt(i);
                    }
                    return true;
                }
            }
            return false;
        }
        public void UpdatePlayerPosition()
        {
            player.Position = player.TargetPosition;
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
                        stateMachine.PointsToRenderOnMap[index] = new Point(player.Position.row + row, player.Position.column + column);
                        index++;
                    }
                }
            }
            for (int i = 0; i < stateMachine.PointsToRenderOnMap.Length; i++)
            {
                levels[(int)stateMachine.CurrentLevel].ExploredLayout[stateMachine.PointsToRenderOnMap[i].row, stateMachine.PointsToRenderOnMap[i].column].IsExplored = true;
            }
        }
        public void ResetPlayerData()
        {
            for (int i = 0; i < stateMachine.PointsToRenderOnMap.Length; i++)
            {
                stateMachine.PointsToRenderOnMap[i] = new Point(0, 0);
            }
            stateMachine.Levels[(int)stateMachine.CurrentLevel].PlayerPositionWhenExit = player.Position;

            if (stateMachine.Levels[(int)stateMachine.NextLevel].PlayerPositionWhenExit.Equals(levels[(int)stateMachine.NextLevel].PlayerStartingTile))
            {
                player.Position = levels[(int)stateMachine.NextLevel].PlayerStartingTile;
                stateMachine.PlayerPosition = player.Position;
            } else
            {
                player.Position = levels[(int)stateMachine.NextLevel].PlayerPositionWhenExit;
                stateMachine.PlayerPosition = player.Position;
            }
        }
    }
}
