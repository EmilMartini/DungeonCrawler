﻿using System;
namespace DungeonCrawler.Doors
{
    public class PurpleDoor : Door
    {
        public PurpleDoor()
        {
            this.Unlock = LockColor.Purple;
            this.IsExplored = false;
            this.Color = ConsoleColor.DarkMagenta;
            this.Graphic = "D";
        }
    }
}
