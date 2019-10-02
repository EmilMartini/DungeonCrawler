using System;
namespace DungeonCrawler
{
    public class ExitDoor : Door
    {
        public ExitDoor()
        {
            this.LockColor = LockColor.Skeleton;
            this.IsExplored = false;
            this.Graphic = "D";
            this.Color = ConsoleColor.DarkGreen;
        }
    }
}
