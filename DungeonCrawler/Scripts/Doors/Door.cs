using System;
namespace DungeonCrawler
{
    public abstract class Door : Tile, IInteractable
    {
        private LockColor lockColor;
        private bool isUnlocked;
        public virtual bool Interact(Player player)
        {
            if (isUnlocked)
            {
                return true;
            }
            else
            {
                foreach (Key key in player.Inventory.KeyRing)
                {
                    if (key.LockColor == this.LockColor)
                    {
                        isUnlocked = true;
                        this.Color = ConsoleColor.White;
                        player.Inventory.KeyRing.Remove(key);
                        GameplayManager.PlaySound("open-close-door");
                        return true;
                    }
                }
                return false;
            }
        }
        public bool IsUnlocked { get => isUnlocked; set => isUnlocked = value; }    //Fixa enkapsulering
        public LockColor LockColor { get => lockColor; set => lockColor = value; }
    }
}
