using System;
using System.Collections.Generic;

namespace DungeonCrawler
{
    class PlayerInventory
    {
        private Player player;
        private List<GameObject> inventory = new List<GameObject>();
        private List<Key> keyRing = new List<Key>();
        public PlayerInventory(Player player)
        {
            this.player = player;
        }

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }
        public List<GameObject> Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }
        public List<Key> KeyRing
        {
            get { return keyRing; }
            set { keyRing = value; }
        }
    }
}
