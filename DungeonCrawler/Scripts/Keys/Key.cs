namespace DungeonCrawler
{
    public abstract class Key : GameObject, IInteractable
    {
        private LockColor unlock;
        private byte numberOfUses;
        public Key(int x, int y)
        {
            this.Position = new Point(x, y);
        }
        public LockColor Unlock
        {
            get { return unlock; }
            set { unlock = value; }
        }
        public byte NumberOfUses
        {
            get { return numberOfUses; }
            set { numberOfUses = value; }
        }
        public bool Interact(Player player)
        {
            player.KeysInInventory.Add(this);
            return true;            
        }
    }
}
