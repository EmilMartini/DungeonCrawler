using System;

namespace DungeonCrawler
{
    public class Player : GameObject
    {
        public Player()
        {
            Inventory = new PlayerInventory(this);
            Graphic = "@";
            Color = ConsoleColor.Green;
            Position = new Point(1,1);
            SurroundingPoints = new Point[8];
        }
        public int EnemiesInteractedWith { get; set; }

        public Point TargetPosition { get; set; }

        public int NumberOfMoves { get; set; }

        public Point[] SurroundingPoints { get; set; }

        internal PlayerInventory Inventory { get; set; }
    }
}
