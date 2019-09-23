

namespace DungeonCrawler
{
    public abstract class Key : Tile, IInteractable
    {
        private bool isEquipped;
        private Unlock unlock;
        private byte numberOfUses;
        private Point location;

        public bool IsEquipped
        {
            get { return isEquipped; }
            set { isEquipped = value; }
        }
        public Unlock Unlock
        {
            get { return unlock; }
            set { unlock = value; }
        }
        public byte NumberOfUses
        {
            get { return numberOfUses; }
            protected set { numberOfUses = value; }
        }

        public Point Location
        {
            get { return location; }
            set { location = value; }
        }

        public void Interact()
        {
            Player.KeysInInventory.Add(this);        
            this.IsExplored = false;
        }
    }
}
