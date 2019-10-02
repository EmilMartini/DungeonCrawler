using System;
using System.Media;
using System.Threading;
using System.Windows;

namespace DungeonCrawler
{
    public abstract class Door : Tile, IInteractable
    {
        private Unlock unlock;
        private bool isUnlocked;
        public bool Interact()
        {
            if (isUnlocked)
            {
                return true;
            }
            else
            {
                foreach (Key key in Player.KeysInInventory)
                {
                    if (key.Unlock == this.unlock)
                    {
                        isUnlocked = true;
                        Player.KeysInInventory.Remove(key);
                        return true;
                    }
                }
                //return false;
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
        public Unlock Unlock
        {
            get { return unlock; }
            set { unlock = value; }
        }
        public bool IsUnlocked { get => isUnlocked; set => isUnlocked = value; }
    }
}
