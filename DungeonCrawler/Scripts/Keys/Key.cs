namespace DungeonCrawler
{
    public abstract class Key : GameObject, IInteractable
    {
        protected Key(int x, int y)
        {
            Position = new Point(x, y);
        }
        public LockColor LockColor { get; set; }
        public byte NumberOfUses { get; set; }
        public bool Interact(Player player)
        {
            GameplayManager.PlaySound("pickup-key");
            player.Inventory.KeyRing.Add(this);
            return true;            
        }
    }
}
