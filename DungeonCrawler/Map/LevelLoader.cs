namespace DungeonCrawler
{
    class LevelLoader
    {
        private Level[] levels;
        private MapController mapController;
        public LevelLoader(Level[] levels, MapController mapController)
        {
            this.levels = levels;
            this.mapController = mapController;
        }
    }
}
