using System;
using System.Linq;

namespace DungeonCrawler
{
    public abstract class Door : Tile, IInteractable
    {
        public virtual bool Interact(Player player)
        {
            if (IsUnlocked)
                return true;

            foreach (var key in player.Inventory.KeyRing.Where(key => key.LockColor == LockColor))
            {
                IsUnlocked = true;
                Color = ConsoleColor.White;
                player.Inventory.KeyRing.Remove(key);
                GameplayManager.PlaySound("unlock-door");
                return true;
            }
            return false;
        }
        public LockColor LockColor { get; set; }
        public bool IsUnlocked { get; set; }
    }
}