using System;

namespace DungeonCrawler
{
    public class TrapDoor : Tile, IInteractable
    {
        public TrapDoor()
        {
            IsExplored = false;
            Color = ConsoleColor.DarkGray;
            Graphic = "_";
        }
        public bool Interact(Player player)
        {
            player.NumberOfMoves += 50;
            return true;
        }
    }
}