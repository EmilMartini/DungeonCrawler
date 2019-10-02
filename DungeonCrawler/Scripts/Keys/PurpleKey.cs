using System;
namespace DungeonCrawler.Keys
{
    public class PurpleKey : Key
    {
        public PurpleKey(int x, int y) : base(x, y)
        {
            this.Position = base.Position;
            this.Unlock = Unlock.Purple;
            this.NumberOfUses = 1;
            this.Color = ConsoleColor.DarkMagenta;
            this.Graphic = "K";
        }
    }
}
