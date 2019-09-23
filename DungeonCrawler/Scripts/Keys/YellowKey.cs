﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Keys
{
    public class YellowKey : Key
    {
        public YellowKey(Point position)
        {
            this.KeyType = KeyType.Yellow;
            this.TileType = TileType.Key;
            this.IsExplored = false;
            this.IsEquipped = false;
            this.NumberOfUses = 1;
            this.Color = ConsoleColor.DarkYellow;
            this.Graphic = "K";
            this.Position = position;
        }
    }
}
