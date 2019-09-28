using System;
using System.Media;
using System.Threading;
using System.Windows;

namespace DungeonCrawler
{
    public abstract class Door : Tile, IInteractable
    {
        private Unlock unlock;
        public bool isUnlocked;

        public Unlock Unlock
        {
            get { return unlock; }
            set { unlock = value; }
        }

        public bool Interact()
        {
            if(isUnlocked)
            {
                return true;
            } else
            {
                if (CanUnlock())
                {
                    this.Color = ConsoleColor.White;
                    this.isUnlocked = true;
                    return true;
                }
            }
            return false;
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
    }
}
