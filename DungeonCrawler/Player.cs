
namespace DungeonCrawler
{
    public class Player : Tile
    {
        public Point Location;        

        public Player(Point playerStartPosition)
        {
            this.Graphic = "@";
            this.TileType = TileType.Player;
            Location = new Point(playerStartPosition.X, playerStartPosition.Y);
        }
    }
}
