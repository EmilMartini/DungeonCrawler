
namespace DungeonCrawler
{
    public class Player : Tile
    {
        public Point Position;        

        public Player(Point playerStartPosition)
        {
            this.Graphic = "@";
            this.TileType = TileType.Player;
            Position = new Point(playerStartPosition.X, playerStartPosition.Y);
        }
    }
}
