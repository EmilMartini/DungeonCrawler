using System;
namespace DungeonCrawler
{
    public class ExitDoor : Door
    {
        public ExitDoor(bool isUnlocked)
        {
            LockColor = LockColor.Skeleton;
            IsExplored = false;
            Graphic = "D";
            Color = ConsoleColor.DarkGreen;
            IsUnlocked = isUnlocked;
        }
    }
}
