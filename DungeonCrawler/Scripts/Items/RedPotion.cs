using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    class RedPotion : Consumable
    {
        public RedPotion(int x, int y)
        {
            NumberOfUses = 1;
            Color = ConsoleColor.Red;
            Graphic = "P";
            Position = new Point(x, y);
        }
        public bool Interact(Player player)
        {
            player.NumberOfMoves += 100;
            return true;
        }
    }
}
