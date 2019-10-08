using System;
using System.Linq;

namespace DungeonCrawler
{
    public abstract class Door : Tile, IInteractable
    {
        public LockColor LockColor { get; set; }
        public bool IsUnlocked { get; set; }
        public virtual bool Interact(Player player)
        {
            if (IsUnlocked)
                return true;

            foreach (var key in player.KeyRing.Where(key => key.LockColor == LockColor))
            {
                IsUnlocked = true;
                Color = ConsoleColor.White;
                player.KeyRing.Remove(key);
                GameplayManager.PlaySound("unlock-door");
                return true;
            }
            return false;
        }
        protected LockColor LockColor { get; set; }
        protected bool IsUnlocked { get; set; }
    }
}