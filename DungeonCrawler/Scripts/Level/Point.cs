namespace DungeonCrawler
{
    public struct Point
    {
        public Point(int x, int y)
        {
            row = x;
            column = y;
        }
        public readonly int row;    //Readonly nödvändigt?
        public readonly int column; //Readonly nödvändigt?
    }
}
