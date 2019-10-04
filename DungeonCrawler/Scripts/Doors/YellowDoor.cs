using System;

namespace DungeonCrawler
{
    public class YellowDoor : Door
    {
        public YellowDoor(bool isUnlocked)
        {
            LockColor = LockColor.Yellow;
            IsExplored = false;
            Color = ConsoleColor.DarkYellow;
            Graphic = "D";
            IsUnlocked = isUnlocked;
        }
    }
}
