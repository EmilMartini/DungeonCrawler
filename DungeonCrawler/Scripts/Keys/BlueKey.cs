using System;
namespace DungeonCrawler.Keys
{
    public class BlueKey : Key
    {
        public BlueKey(int x, int y) : base(x,y)
        {
            this.Unlock = LockColor.Blue;
            this.NumberOfUses = 1;
            this.Color = ConsoleColor.DarkBlue;
            this.Graphic = "K";
        }
    }
}
