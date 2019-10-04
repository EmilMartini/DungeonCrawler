using System;
namespace DungeonCrawler
{
    public class YellowDoor : Door
    {
        public YellowDoor(bool isUnlocked)
        {
            this.LockColor = LockColor.Yellow;
            this.IsExplored = false;
            this.Color = ConsoleColor.DarkYellow;
            this.Graphic = "D";
            this.IsUnlocked = isUnlocked;
        }
    }
}
