using System;

namespace DungeonCrawler
{
    public class RedPotion : Consumable, IInteractable
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
