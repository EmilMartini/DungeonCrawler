namespace DungeonCrawler
{
    public struct Point
    {
        public Point(int x, int y)
        {
            Row = x;
            Column = y;
        }
        public readonly int Row;
        public readonly int Column;
    }
}
