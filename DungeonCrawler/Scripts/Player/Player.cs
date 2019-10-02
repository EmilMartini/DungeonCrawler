using System;
using System.Collections.Generic;
namespace DungeonCrawler
{
    public class Player : GameObject
    {   
        private Point targetPosition;
        private Point[] surroundingPoints;
        private PlayerInventory inventory;
        private int enemiesInteractedWith = 0;
        private int numberOfMoves;
        public Player()
        {
            this.Inventory = new PlayerInventory(this);
            this.Graphic = "@";
            this.Color = ConsoleColor.Green;
            this.Position = new Point(1,1);
            this.SurroundingPoints = new Point[8];
        }
        public int EnemiesInteractedWith
        {
            get { return enemiesInteractedWith; }
            set { enemiesInteractedWith = value; }
        }
        public Point TargetPosition
        {
            get { return targetPosition; }
            set { targetPosition = value; }
        }
        public int NumberOfMoves
        {
            get { return numberOfMoves; }
            set { numberOfMoves = value; }
        }
        public Point[] SurroundingPoints
        {
            get { return surroundingPoints; }
            set { surroundingPoints = value; }
        }
        internal PlayerInventory Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }
    }
}
