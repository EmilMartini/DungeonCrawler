using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Keys
{
    public class PurpleKey : Key
    {
        public PurpleKey()
        {
            this.Unlock = Unlock.Purple;
            this.TileType = TileType.Key;
            this.IsExplored = false;
            this.IsEquipped = false;
            this.NumberOfUses = 1;
            this.Color = ConsoleColor.DarkMagenta;
            this.Graphic = "K";
        }
    }
}
