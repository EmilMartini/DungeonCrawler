using System;
namespace DungeonCrawler
{
    public abstract class Door : Tile, IInteractable
    {
        public virtual bool Interact(Player player)
        {
            if (IsUnlocked)
            {
                return true;
            }
            else
            {
                foreach (Key key in player.Inventory.KeyRing)
                {
                    if (key.LockColor != LockColor)
                        continue;
                    
                    IsUnlocked = true;
                    Color = ConsoleColor.White;
                    player.Inventory.KeyRing.Remove(key);
                    GameplayManager.PlaySound("open-close-door");
                    return true;                    
                }
                return false;
            }
        }
        public LockColor LockColor { get; set; }
        public bool IsUnlocked { get; set; }
    }
}
