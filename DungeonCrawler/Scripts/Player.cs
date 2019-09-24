﻿using System;
using System.Collections.Generic;

namespace DungeonCrawler
{
    public class Player : Tile
    {
        private Point position;
        private uint numberOfMoves;
        private static List<Key> keysInInventory = new List<Key>();
        private static int enemiesInteractedWith = 0;

        public Player()
        {
            this.Graphic = "@";
            this.TileType = TileType.Player;
            this.IsExplored = true;
            this.Color = ConsoleColor.Green;
            this.Position = new Point(1,1);
        }

        public Point Position
        {
            get { return position; }
            set { position = value; }
        }
        public uint NumberOfMoves
        {
            get { return numberOfMoves; }
            set { numberOfMoves = value; }
        }
        public static List<Key> KeysInInventory
        {
            get { return keysInInventory; }
            set { keysInInventory = value; }
        }
        public static int EnemiesInteractedWith
        {
            get { return enemiesInteractedWith; }
            set { enemiesInteractedWith = value; }
        }
    }
}