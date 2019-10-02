using System;
using System.Collections.Generic;
namespace DungeonCrawler
{
    public class Player : GameObject
    {   
        private Point targetPosition;
        private Point[] pointsAroundPlayer;
        private PlayerInventory playerInventory;
        private int enemiesInteractedWith = 0;
        private int numberOfMoves;
        public Player()
        {
            this.PlayerInventory = new PlayerInventory(this);
            this.Graphic = "@";
            this.Color = ConsoleColor.Green;
            this.Position = new Point(1,1);
            this.PointsAroundPlayer = new Point[8];
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
        public Point[] PointsAroundPlayer
        {
            get { return pointsAroundPlayer; }
            set { pointsAroundPlayer = value; }
        }
        internal PlayerInventory PlayerInventory
        {
            get { return playerInventory; }
            set { playerInventory = value; }
        }
    }
}
