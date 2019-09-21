﻿using System;

namespace DungeonCrawler
{
    public abstract class Tile
    {
        private TileType tileType;
        private string graphic;
        private bool isExplored;
        private ConsoleColor color;

        public TileType TileType
        {
            get { return tileType; }
            protected set { tileType = value; }
        }
        public string Graphic
        {
            get { return graphic; }
            protected set { graphic = value; }
        }
        public bool IsExplored
        {
            get { return isExplored; }
            set { isExplored = value; }
        }
        public ConsoleColor Color
        {
            get { return color; }
            protected set { color = value; }
        }
    }
}