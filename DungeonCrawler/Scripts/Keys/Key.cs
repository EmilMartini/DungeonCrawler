namespace DungeonCrawler
{
    public abstract class Key : GameObject, IInteractable
    {
        protected Key(int x, int y)
        {
            Position = new Point(x, y);
        }
        public LockColor LockColor { get; set; }
        public bool Interact(Player player)
        {
            GameplayManager.PlaySound("pickup-key");
            player.KeyRing.Add(this);
            return true;            
        }
    }
}
