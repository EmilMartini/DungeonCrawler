using System;
namespace DungeonCrawler.Doors
{
    public class BlueDoor : Door
    {
        public BlueDoor()
        {
            this.LockColor = LockColor.Blue;
            this.IsExplored = false;
            this.Color = ConsoleColor.DarkBlue;
            this.Graphic = "D";
            this.IsUnlocked = false;
        }
    }
}
