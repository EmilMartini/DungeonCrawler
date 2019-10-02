using System;
namespace DungeonCrawler
{
    public class ExitDoor : Door
    {
        public ExitDoor()
        {
            this.Unlock = LockColor.Skeleton;
            this.IsExplored = false;
            this.Graphic = "D";
            this.Color = ConsoleColor.DarkGreen;
        }
    }
}
