using System;

namespace DungeonCrawler
{
    public class TrapDoor : Tile
    {
        public TrapDoor( )
        {
            IsExplored = false;
            Color = ConsoleColor.DarkGray;
            Graphic = "_";
        }
        public bool Interact()
        {
            return true;
        }
    }
}