using System;
using System.Collections.Generic;

namespace DungeonCrawler
{
    public class Player : GameObject
    {
        private Point targetPlayerPosition;
        private static List<Key> keysInInventory = new List<Key>();
        private static int enemiesInteractedWith = 0;

        public Player()
        {
            this.Graphic = "@";
            this.Color = ConsoleColor.Green;
            this.Position = new Point(1,1);
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
        public Point TargetPosition { get; set; }
    }
}
