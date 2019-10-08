using System;

namespace DungeonCrawler
{
    public class Enemy : GameObject, IInteractable
    {
        public Enemy(Point spawnPoint)
        {
            Graphic = "X";
            Color = ConsoleColor.Red;
            Position = spawnPoint;
        }
        public bool Interact(Player player)
        {
            player.EnemiesInteractedWith++;
            GameplayManager.PlaySound("monster-moan");
            return true;
        }
    }
}
