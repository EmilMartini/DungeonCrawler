

using System;
using System.Media;

namespace DungeonCrawler
{
    public abstract class Key : GameObject, IInteractable
    {
        private Unlock unlock;
        private byte numberOfUses;
        public Key(int x, int y)
        {
            this.Position = new Point(x, y);
        }

        public Unlock Unlock
        {
            get { return unlock; }
            set { unlock = value; }
        }
        public byte NumberOfUses
        {
            get { return numberOfUses; }
            set { numberOfUses = value; }
        }
        public bool Interact()
        {
            
            return true;
        }
    }
}
