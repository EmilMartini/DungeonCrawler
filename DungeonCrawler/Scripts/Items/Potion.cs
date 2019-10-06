using System;

namespace DungeonCrawler
{
    public class Potion : Consumable, IInteractable
    {
        public Potion(int x, int y)
        {
            NumberOfUses = 1;
            Color = ConsoleColor.Cyan;
            Graphic = "P";
            Position = new Point(x, y);
        }
        public bool Interact(Player player)
        {
            if(player.NumberOfMoves - 50 <= 0)
                player.NumberOfMoves = 0;
            else
                player.NumberOfMoves -= 50;
            return true;
        }
    }
}
