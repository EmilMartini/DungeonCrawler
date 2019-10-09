using System;

namespace DungeonCrawler
{
    public class RedPotion : GameObject, IInteractable
    {
        public RedPotion(int x, int y)
        {
            Color = ConsoleColor.Red;
            Graphic = "P";
            Position = new Point(x, y);
        }
        public bool Interact(Player player)
        {
            player.NumberOfMoves += 100;
            GameplayManager.PlaySound("potion-interact");
            return true;
        }
    }
}
