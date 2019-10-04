using System;
namespace DungeonCrawler
{
    public class PurpleDoor : Door
    {
        public PurpleDoor()
        {
            LockColor = LockColor.Purple;
            IsExplored = false;
            Color = ConsoleColor.DarkMagenta;
            Graphic = "D";
        }
    }
}
