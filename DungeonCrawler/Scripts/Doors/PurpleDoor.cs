using System;
namespace DungeonCrawler
{
    public class PurpleDoor : Door
    {
        public PurpleDoor()
        {
            this.LockColor = LockColor.Purple;
            this.IsExplored = false;
            this.Color = ConsoleColor.DarkMagenta;
            this.Graphic = "D";
        }
    }
}
