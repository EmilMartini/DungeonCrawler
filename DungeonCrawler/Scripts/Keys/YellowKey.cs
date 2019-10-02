﻿using System;
namespace DungeonCrawler.Keys
{
    public class YellowKey : Key
    {
        public YellowKey(int x, int y) : base(x,y)
        {
            this.Position = base.Position;
            this.Unlock = Unlock.Yellow;
            this.NumberOfUses = 1;
            this.Color = ConsoleColor.DarkYellow;
            this.Graphic = "K";
        }
    }
}
