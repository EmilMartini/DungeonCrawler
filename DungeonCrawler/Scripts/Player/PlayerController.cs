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
            var currentLevel = gameplayManager.Levels[gameplayManager.CurrentLevel];
            if (direction.Equals(new Point(0, 0)))
                return;
            
            player.TargetPosition = new Point(player.Position.Row + direction.Row, player.Position.Column + direction.Column);
            if (currentLevel.Layout[player.TargetPosition.Row, player.TargetPosition.Column] is Wall)
                return;
            
            if (!CheckInteraction(player.TargetPosition, gameplayManager)) 
                return;
            
            UpdatePlayerPosition();
            player.NumberOfMoves++;
        }
        private bool CheckInteraction(Point targetPosition, GameplayManager gameplayManager)
        {
            if (gameplayManager.Levels[gameplayManager.CurrentLevel].Layout[targetPosition.Row, targetPosition.Column] is IInteractable interactableTile)
            {
                if (!interactableTile.Interact(player))
                    return false;
                
                if (!(interactableTile is ExitDoor)) 
                    return true;

            }
            foreach (var gameObject in gameplayManager.Levels[gameplayManager.CurrentLevel].ActiveGameObjects)
            {
                if (gameObject is Player)
                    continue;

                if (!gameObject.Position.Equals(targetPosition) ||
                    !(gameObject is IInteractable interactableGameObject))
                    continue;
                
                if (!interactableGameObject.Interact(player)) 
                    return false;
                
                gameplayManager.RemoveGameObject(gameObject);
                return true;
            }
            return true;
        }

        private void UpdatePlayerPosition()
        {
            player.Position = player.TargetPosition;
        }
        public void ExploreSurroundingTiles(GameplayManager gameplayManager)
        {
            var index = 0;
            var currentLevelLayout = gameplayManager.Levels[gameplayManager.CurrentLevel].Layout;
            for (var row = (-1); row < 2; row++)
            {
                for (var column = (-1); column < 2; column++)
                {
                    if (!(row != 0 || column != 0)) 
                        continue;
                    
                    player.SurroundingPoints[index] = new Point(player.Position.Row + row, player.Position.Column + column);
                    index++;
                }
            }
            for (var i = 0; i < player.SurroundingPoints.Length; i++)
            {
                currentLevelLayout[player.SurroundingPoints[i].Row, player.SurroundingPoints[i].Column].IsExplored = true;
            }
        }
        public void ResetPositionData(GameplayManager gameplayManager)
        {
            var currentLevel = gameplayManager.Levels[gameplayManager.CurrentLevel];
            var nextLevel = gameplayManager.Levels[gameplayManager.NextLevel];
            for (var i = 0; i < player.SurroundingPoints.Length; i++)
            {
                player.SurroundingPoints[i] = new Point(0, 0);
            }
            currentLevel.PlayerExitPosition = player.Position;
            
            player.Position = nextLevel.PlayerExitPosition.Equals(nextLevel.PlayerStartingTile) ?
                nextLevel.PlayerStartingTile :
                nextLevel.PlayerExitPosition;
        }
    }
}
