using System;
using System.Collections.Generic;

namespace DungeonCrawler
{
    public class Player : Tile
    {
        private Point position;
        private Point targetPlayerPosition;
        private List<Key> keysInInventory = new List<Key>();
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
        public List<Key> KeysInInventory
        {
            get { return keysInInventory; }
            set { keysInInventory = value; }
        }
        public static int EnemiesInteractedWith
        {
            get { return enemiesInteractedWith; }
            set { enemiesInteractedWith = value; }
        }

        public Point TargetPlayerPosition { get; set; }
    }
}
