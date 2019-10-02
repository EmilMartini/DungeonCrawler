using System;
namespace DungeonCrawler.Doors
{
    public class BlueDoor : Door
    {
        public BlueDoor()
        {
            this.Unlock = LockColor.Blue;
            this.IsExplored = false;
            this.Color = ConsoleColor.DarkBlue;
            this.Graphic = "D";    
        }
    }
}
