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
            return true;
        }

        public bool CanUnlock(Key[] keys)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i].Unlock.Equals((Unlock)i))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
