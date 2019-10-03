namespace DungeonCrawler
{
    public abstract class Tile : Entity
    {
        private bool isExplored;
        public bool IsExplored
        {
            get { return isExplored; }
            set { isExplored = value; }
        }
    }
}