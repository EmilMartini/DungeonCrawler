using System;

namespace DungeonCrawler
{
    public class TrapDoor : Tile
    {
        //Använda alls?
        public TrapDoor( )
        {
            this.IsExplored = false;
            this.Color = ConsoleColor.DarkGray;
            this.Graphic = ".";
        }

        public bool Interact()
        {
            return true;
        }
    }
}