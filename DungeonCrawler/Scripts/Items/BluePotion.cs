using System;

namespace DungeonCrawler
{
    public class BluePotion : GameObject, IInteractable
    {
        public BluePotion(int x, int y)
        {
            Color = ConsoleColor.Cyan;
            Graphic = "P";
            Position = new Point(x, y);
        }
        public bool Interact(Player player)
        {
            GameplayManager.PlaySound("potion-interact");
            if (player.NumberOfMoves - 100 <= 0)
                player.NumberOfMoves = 0;
            else
                player.NumberOfMoves -= 100;
            return true;
        }
    }
}
