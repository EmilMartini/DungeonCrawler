
namespace DungeonCrawler
{
    public class Player : Tile
    {
        public Point Location;        

        public Player(int x, int y)
        {
            this.Graphic = "@";
            this.TileType = TileType.Player;
            Location = new Point(x, y);
        }
    }
}
