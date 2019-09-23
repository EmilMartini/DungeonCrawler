

namespace DungeonCrawler
{
    public abstract class Key : Tile, IInteractable
    {
        private bool isEquipped;
        private KeyType keyType;
        private byte numberOfUses;
        private Point position;

        public bool IsEquipped
        {
            get { return isEquipped; }
            set { isEquipped = value; }
        }
        public KeyType KeyType
        {
            get { return keyType; }
            set { keyType = value; }
        }
        public byte NumberOfUses
        {
            get { return numberOfUses; }
            protected set { numberOfUses = value; }
        }

        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        public void Interact()
        {
            Player.KeysInInventory.Add(this);                   
        }
    }
}
