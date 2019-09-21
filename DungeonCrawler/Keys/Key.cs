using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class Key : Tile
    {
        private bool isEquipped;
        private KeyType keyType;
        private byte numberOfUses;

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
    }
}
