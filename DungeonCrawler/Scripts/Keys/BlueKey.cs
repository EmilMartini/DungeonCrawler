using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Keys
{
    public class BlueKey : Key
    {
        public BlueKey()
        {
            this.Unlock = Unlock.Blue;
            this.IsExplored = false;
            this.IsEquipped = false;
            this.NumberOfUses = 1;
            this.Color = ConsoleColor.DarkBlue;
            this.Graphic = "K";
        }
    }
}
