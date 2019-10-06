using System.Collections.Generic;

namespace DungeonCrawler
{
    class PlayerInventory
    {
        public PlayerInventory(Player player)
        {
            this.Player = player;
        }
        public Player Player { get; set; }
        public List<GameObject> Inventory { get; set; } = new List<GameObject>();
        public List<Key> KeyRing { get; set; } = new List<Key>();
    }
}
