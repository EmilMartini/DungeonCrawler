using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class Door : Tile, IInteractable
    {
        private Unlock unlock;

        public Unlock Unlock
        {
            get { return unlock; }
            set { unlock = value; }
        }

        public bool Interact()
        {
            if (CanUnlock())
            {
                return true;
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
