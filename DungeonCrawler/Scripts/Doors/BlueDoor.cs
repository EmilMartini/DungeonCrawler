using System;
namespace DungeonCrawler
{
    public class BlueDoor : Door
    {
        public BlueDoor()
        {
            LockColor = LockColor.Blue;
            IsExplored = false;
            Color = ConsoleColor.DarkBlue;
            Graphic = "D";
            IsUnlocked = false;
        }
    }
}
