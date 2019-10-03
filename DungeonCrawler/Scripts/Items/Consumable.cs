namespace DungeonCrawler
{
    public abstract class Consumable : GameObject
    {
        private uint numberOfUses;
        public uint NumberOfUses
        {
            get { return numberOfUses; }
            set { numberOfUses = value; }
        }
    }
}
