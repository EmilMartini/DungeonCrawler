﻿using System;
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
            this.playerInventory = player.PlayerInventory;
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
            if (gameplayManager.Levels[(int)gameplayManager.CurrentLevel].Layout[targetPosition.row, targetPosition.column] is IInteractable interactableTile)  //borde gå att få bättre syntax
            {           
                return interactableTile.Interact(player);
            }
            foreach (GameObject gameObject in gameplayManager.Levels[(int)gameplayManager.CurrentLevel].ActiveGameObjects)
            {
                if (gameObject is Player)
                {
                    continue;
                }
                else if (gameObject.Position.Equals(targetPosition) && gameObject is IInteractable interactableGameObject)
                {
                    interactableGameObject.Interact(player);
                    if (interactableGameObject is Key key)
                    {
                        gameplayManager.Levels[(int)gameplayManager.CurrentLevel].ActiveGameObjects.Remove(key);    //Eventuellt ropa på metod i framtida PlayerInventoryKlassen
                        return true;
                    }
                }
            }
            return true;
        }
        public void UpdatePlayerPosition()
        {
            player.Position = player.TargetPosition;    //onödig?
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
                        player.PointsAroundPlayer[index] = new Point(player.Position.row + row, player.Position.column + column);
                        index++;
                    }
                }
            }
            for (int i = 0; i < player.PointsAroundPlayer.Length; i++)
            {
                levels[(int)gameplayManager.CurrentLevel].Layout[player.PointsAroundPlayer[i].row, player.PointsAroundPlayer[i].column].IsExplored = true; //Kanske snyggare syntax
            }
        }
        public void ResetPlayerData()   //Kommentera, otydlig inuti
        {
            for (int i = 0; i < player.PointsAroundPlayer.Length; i++)
            {
                player.PointsAroundPlayer[i] = new Point(0, 0);
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