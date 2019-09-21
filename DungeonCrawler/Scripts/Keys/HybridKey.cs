using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Keys
{
    public class HybridKey : Key
    {
        public HybridKey()
        {
            this.KeyType = KeyType.Hybrid;
            this.TileType = TileType.Key;
            this.IsExplored = false;
            this.IsEquipped = false;
            this.NumberOfUses = 2;
            this.Color = ConsoleColor.DarkGreen;
            this.Graphic = "K";
        }
    }
}
