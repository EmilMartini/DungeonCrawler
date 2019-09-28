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
            if(IsUnlocked)
            {
                return true;
            } else if (!CanUnlock())
            {
                return false;
            } else
            {
                this.Color = ConsoleColor.White;
                this.IsUnlocked = true;
                return true;
            }
        }
        public bool CanUnlock()
        {
            for (int i = 0; i < Player.KeysInInventory.Count; i++)
            {
                if (Player.KeysInInventory[i].Unlock.Equals((this.Unlock)))
                {
                    Player.KeysInInventory[i].NumberOfUses--;
                    if (Player.KeysInInventory[i].NumberOfUses <= 0)
                    {
                        Player.KeysInInventory.RemoveAt(i);
                    }
                    return true;
                }
            }
            return false;
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
