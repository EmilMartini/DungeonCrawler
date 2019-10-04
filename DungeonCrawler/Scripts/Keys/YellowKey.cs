using System;
namespace DungeonCrawler
{
    public class YellowKey : Key
    {
        public YellowKey(int x, int y) : base(x,y)
        {
            Position = Position;
            LockColor = LockColor.Yellow;
            NumberOfUses = 1;
            Color = ConsoleColor.DarkYellow;
            Graphic = "K";
        }
    }
}
