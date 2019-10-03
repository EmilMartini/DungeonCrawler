using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Potion : Consumable, IInteractable
    {
        public Potion(int x, int y)
        {
            this.NumberOfUses = 1;
            this.Color = ConsoleColor.Cyan;
            this.Graphic = "P";
            this.Position = new Point(x, y);
        }

        public bool Interact(Player player)
        {
            if(player.NumberOfMoves - 50 <= 0)
            {
                player.NumberOfMoves = 0;
            } else
            {
                player.NumberOfMoves -= 50;
            }
            return true;
        }
    }
}
