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
                foreach (Key key in player.KeysInInventory)
                {
                    if (key.LockColor == this.LockColor)
                    {
                        isUnlocked = true;
                        this.Color = ConsoleColor.White;
                        player.KeysInInventory.Remove(key);
                        return true;
                    }
                }
                return false;
            }
        }
        public bool CanUnlock()
        {
            return true;
        }
        protected bool hasUnlocked()
        {
            if(this.isUnlocked)
            {
                return true;
            } else
            {
                return false;
            }
        }
        public LockColor LockColor
        {
            get { return lockColor; }
            set { lockColor = value; }
        }
        public bool IsUnlocked { get => isUnlocked; set => isUnlocked = value; }
    }
}
