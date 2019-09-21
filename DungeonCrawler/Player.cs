using System;

namespace DungeonCrawler
{
    public class Player : Tile
    {
        private Point position;        
        public Player(Point playerSpawn)
        {
            this.Graphic = "@";
            this.TileType = TileType.Player;
            this.IsExplored = true;
            this.Color = ConsoleColor.Green;

            this.Position = new Point(playerSpawn.row, playerSpawn.column);
            
        }

        public Point Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
