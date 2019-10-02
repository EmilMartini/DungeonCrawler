using System;
namespace DungeonCrawler.Doors
{
    public class PurpleDoor : Door
    {
        public PurpleDoor()
        {
            this.Unlock = Unlock.Purple;
            this.IsExplored = false;
            this.Color = ConsoleColor.DarkMagenta;
            this.Graphic = "D";
        }
    }
}
