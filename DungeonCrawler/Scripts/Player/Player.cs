using System;
using System.Collections.Generic;

namespace DungeonCrawler
{
    public class Player : GameObject
    {
        public Player()
        {
            Graphic = "@";
            Color = ConsoleColor.Green;
            Position = new Point(1,1);
            SurroundingPoints = new Point[8];
        }
        public int EnemiesInteractedWith { get; set; }
        public Point TargetPosition { get; set; }
        public int NumberOfMoves { get; set; }
        public Point[] SurroundingPoints { get; set; }
        public List<Key> KeyRing { get; set; } = new List<Key>();
    }
}
