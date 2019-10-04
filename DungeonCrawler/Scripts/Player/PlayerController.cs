using System;
namespace DungeonCrawler
{
    public class PlayerController
    {
        private readonly Player player;
        private readonly PlayerInventory playerInventory;

        public PlayerController(Player player)
        {
            this.player = player;
            playerInventory = player.Inventory;
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
        public void MovePlayer(Point direction, GameplayManager gameplayManager)
        {
            var currentLevel = gameplayManager.Levels[(int)gameplayManager.CurrentLevel];
            if(!direction.Equals(new Point(0,0)))
            {
                player.TargetPosition = new Point(player.Position.row + direction.row, player.Position.column + direction.column);
                if (!(currentLevel.Layout[player.TargetPosition.row, player.TargetPosition.column] is Wall))
                {
                    if (CheckInteraction(player.TargetPosition, gameplayManager))
                    {
                        UpdatePlayerPosition();
                        player.NumberOfMoves++;  
                    }
                }          
            }
        }
        private bool CheckInteraction(Point targetPosition, GameplayManager gameplayManager)
        {
            if (gameplayManager.Levels[gameplayManager.CurrentLevel].Layout[targetPosition.row, targetPosition.column] is IInteractable interactableTile)
            {   
                if(interactableTile.Interact(player))
                {
                    if(interactableTile is ExitDoor)
                    {                       
                        gameplayManager.CurrentState = GameplayState.ShowScore;
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            foreach (GameObject gameObject in gameplayManager.Levels[gameplayManager.CurrentLevel].ActiveGameObjects)
            {
                if (gameObject is Player)
                {
                    continue;
                }
                else if (gameObject.Position.Equals(targetPosition) && gameObject is IInteractable interactableGameObject)
                {
                    if (interactableGameObject.Interact(player))
                    {
                        gameplayManager.RemoveGameObject(gameObject);
                        return true;
                    } else
                    {
                        return false;
                    }
                } 
            }
            return true;
        }
        public void UpdatePlayerPosition()
        {
            player.Position = player.TargetPosition;    //onödig?
        }
        public void ExploreSurroundingTiles(GameplayManager gameplayManager)
        {
            int index = 0;
            Tile[,] currentLevelLayout = gameplayManager.Levels[(int)gameplayManager.CurrentLevel].Layout;
            for (int row = (-1); row < 2; row++)
            {
                for (int column = (-1); column < 2; column++)
                {
                    if ((row != 0 | column != 0))
                    {
                        player.SurroundingPoints[index] = new Point(player.Position.row + row, player.Position.column + column);
                        index++;
                    }
                }
            }
            for (int i = 0; i < player.SurroundingPoints.Length; i++)
            {
                currentLevelLayout[player.SurroundingPoints[i].row, player.SurroundingPoints[i].column].IsExplored = true;
            }
        }
        public void ResetPositionData(GameplayManager gameplayManager)
        {
            var currentLevel = gameplayManager.Levels[(int)gameplayManager.CurrentLevel];
            var nextLevel = gameplayManager.Levels[(int)gameplayManager.NextLevel];
            for (int i = 0; i < player.SurroundingPoints.Length; i++)
            {
                player.SurroundingPoints[i] = new Point(0, 0);
            }
            currentLevel.PlayerExitPosition = player.Position;
            if (nextLevel.PlayerExitPosition.Equals(nextLevel.PlayerStartingTile))
            {
                player.Position = nextLevel.PlayerStartingTile;
            }
            else
            {
                player.Position = nextLevel.PlayerExitPosition;
            }
        }
    }
}
