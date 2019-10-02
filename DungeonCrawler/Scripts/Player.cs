﻿using System;
using System.Collections.Generic;

namespace DungeonCrawler
{
    public class Player : GameObject
    {
        private Point targetPlayerPosition;
        private List<Key> keysInInventory = new List<Key>();
        private int enemiesInteractedWith = 0;
        private int numberOfMoves;

        public Player()
        {
            this.Graphic = "@";
            this.Color = ConsoleColor.Green;
            this.Position = new Point(1,1);
        }
        public List<Key> KeysInInventory    //skapa egen klass "PlayerInventory"
        {
            get { return keysInInventory; }
            set { keysInInventory = value; }
        }
        public int EnemiesInteractedWith
        {
            get { return enemiesInteractedWith; }
            set { enemiesInteractedWith = value; }
        }
        public Point TargetPosition { get; set; }
        public int NumberOfMoves { get => numberOfMoves; set => numberOfMoves = value; }    //Fixa samma enkapsulering som andra properties
    }
}
