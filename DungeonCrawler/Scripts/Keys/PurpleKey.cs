﻿using System;

namespace DungeonCrawler
{
    public class PurpleKey : Key
    {
        public PurpleKey(int x, int y) : base(x, y)
        {
            Position = Position;
            LockColor = LockColor.Purple;
            Color = ConsoleColor.DarkMagenta;
            Graphic = "K";
        }
    }
}
