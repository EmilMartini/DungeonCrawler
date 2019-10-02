namespace DungeonCrawler
{
    public abstract class Key : GameObject, IInteractable
    {
        private LockColor lockColor;
        private byte numberOfUses;
        public Key(int x, int y)
        {
            this.Position = new Point(x, y);
        }
        public LockColor LockColor
        {
            get { return lockColor; }
            set { lockColor = value; }
        }
        public byte NumberOfUses
        {
            get { return numberOfUses; }
            set { numberOfUses = value; }
        }
        public bool Interact(Player player)
        {
            player.Inventory.KeyRing.Add(this);
            return true;            
        }
    }
}
