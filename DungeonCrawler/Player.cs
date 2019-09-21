using System;

namespace DungeonCrawler
{
    public class Player : Tile
    {
        public Point Position;        
        public Player(Point playerSpawn)
        {
            this.Graphic = "@";
            this.TileType = TileType.Player;
            this.IsExplored = true;
            this.Color = ConsoleColor.Green;

            Position = new Point(playerSpawn.row, playerSpawn.column);
            
        }
    }
}
