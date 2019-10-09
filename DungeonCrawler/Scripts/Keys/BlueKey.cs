using System;

namespace DungeonCrawler
{
    public class BlueKey : Key
    {
        public BlueKey(int x, int y) : base(x,y)
        {
            LockColor = LockColor.Blue;
            Color = ConsoleColor.DarkBlue;
            Graphic = "K";
        }
    }
}
