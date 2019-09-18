namespace DungeonCrawler
{
    public class Player : Tile
    {
        public Point Position;        
        public Player(Point playerStartPosition)
        {
            this.Graphic = "@";
            this.TileType = TileType.Player;
            this.isExplored = true;
            Position = new Point(playerStartPosition.row, playerStartPosition.column);
        }
    }
}
