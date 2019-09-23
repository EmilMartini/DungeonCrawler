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

        public void Interact()
        {
            if(CanUnlock)
        }

        public bool CanUnlock()
        {
            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i].Unlock.Equals((this.Unlock)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
