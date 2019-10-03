using System;
namespace DungeonCrawler
{
    public class BlueKey : Key
    {
        public BlueKey(int x, int y) : base(x,y)
        {
            this.LockColor = LockColor.Blue;
            this.NumberOfUses = 1;
            this.Color = ConsoleColor.DarkBlue;
            this.Graphic = "K";
        }
    }
}
