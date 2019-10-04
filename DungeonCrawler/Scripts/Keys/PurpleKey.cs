using System;
namespace DungeonCrawler
{
    public class PurpleKey : Key
    {
        public PurpleKey(int x, int y) : base(x, y)
        {
            this.Position = base.Position;
            this.LockColor = LockColor.Purple;
            this.NumberOfUses = 1;
            this.Color = ConsoleColor.DarkMagenta;
            this.Graphic = "K";
        }
    }
}
