﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Enemy : Tile, IInteractable
    {
        private Point position;

        public Enemy(int startRow, int startColumn)
        {
            this.TileType = TileType.Enemy;
            this.Graphic = "X";
            this.IsExplored = false;
            this.Color = ConsoleColor.Red;
            Position = new Point(startRow, startColumn);
        }

        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        public bool Interact()
        {
            Player.EnemiesInteractedWith++;
            return true;
        }
    }
}