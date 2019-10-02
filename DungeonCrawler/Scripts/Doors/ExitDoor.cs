using System;
namespace DungeonCrawler
{
    public class ExitDoor : Door
    {
        public ExitDoor(bool isUnlocked)
        {
            this.LockColor = LockColor.Skeleton;
            this.IsExplored = false;
            this.Graphic = "D";
            this.Color = ConsoleColor.DarkGreen;
            this.IsUnlocked = isUnlocked;
        }
    }
}
