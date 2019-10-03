using System;
namespace DungeonCrawler
{
    class PressurePlate : Tile, IInteractable
    {
        public PressurePlate(int x, int y)
        {
            this.Color = ConsoleColor.Gray;
            this.Graphic = ".";
            this.Position = new Point(x, y);
        }
        public bool Interact(Player player)
        {
            GameplayManager.PlaySound("UnlockDoor");
            return true;
        }
    }
}
