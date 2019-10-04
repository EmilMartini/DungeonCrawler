using System;
namespace DungeonCrawler
{
    public class TrapDoor : Tile
    {
        public TrapDoor( )
        {
            IsExplored = false;
            Color = ConsoleColor.DarkGray;
            Graphic = ".";
        }
        public bool Interact()
        {
            return true;
        }
    }
}