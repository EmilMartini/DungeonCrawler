using System;
namespace DungeonCrawler
{
    public class PlayerController
    {
        private GameplayManager gameplayManager;
        private readonly Level[] levels;    //Ta bort?
        private readonly Player player;
        private readonly PlayerInventory playerInventory;

        public PlayerController(Player player, GameplayManager gameplayManager)
        {
            this.player = player;
            this.playerInventory = player.Inventory;
            this.levels = gameplayManager.Levels;
            this.gameplayManager = gameplayManager;
            gameplayManager.Levels[(int)gameplayManager.CurrentLevel].ActiveGameObjects.Add(player);
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
                if (!(levels[(int)gameplayManager.CurrentLevel].Layout[player.TargetPosition.row, player.TargetPosition.column] is Wall))
                {
                    if (CheckInteraction(player.TargetPosition))
                    {
                        UpdatePlayerPosition();
                        player.NumberOfMoves++;  
                    }
                }          
            }
        }
        private bool CheckInteraction(Point targetPosition)
        {
            //Check if interactable is tile
            if (levels[(int)gameplayManager.CurrentLevel].Layout[targetPosition.row, targetPosition.column] is IInteractable interactableTile)  //borde gå att få bättre syntax
            {   
                if(interactableTile.Interact(player))
                {
                    if(interactableTile is ExitDoor)
                    {                       
                        gameplayManager.CurrentState = State.ShowScore;
                        return true;
                    } else if(interactableTile is PressurePlate)
                    {
                        gameplayManager.UnlockHiddenDoor((Door)levels[(int)gameplayManager.CurrentLevel].Layout[1, 1]);
                        return true;
                    } else
                    {
                        return true;
                    }
                } else
                {
                    return false;
                }
            }

            //Check if interactable is gameobject
            foreach (GameObject gameObject in levels[(int)gameplayManager.CurrentLevel].ActiveGameObjects)
            {
                if (gameObject is Player)
                {
                    continue;
                } else if (gameObject.Position.Equals(targetPosition) && gameObject is IInteractable interactableGameObject)
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
        public void ExploreSurroundingTiles()
        {
            int index = 0;
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
                levels[(int)gameplayManager.CurrentLevel].Layout[player.SurroundingPoints[i].row, player.SurroundingPoints[i].column].IsExplored = true; //Kanske snyggare syntax
            }
        }
        public void ResetData()   //Kommentera, otydlig inuti
        {
            for (int i = 0; i < player.SurroundingPoints.Length; i++)
            {
                player.SurroundingPoints[i] = new Point(0, 0);
            }
            gameplayManager.Levels[(int)gameplayManager.CurrentLevel].PlayerPositionWhenExit = player.Position;

            if (gameplayManager.Levels[(int)gameplayManager.NextLevel].PlayerPositionWhenExit.Equals(levels[(int)gameplayManager.NextLevel].PlayerStartingTile))
            {
                player.Position = levels[(int)gameplayManager.NextLevel].PlayerStartingTile;
            } else
            {
                player.Position = levels[(int)gameplayManager.NextLevel].PlayerPositionWhenExit;
            }
        }
    }
}
