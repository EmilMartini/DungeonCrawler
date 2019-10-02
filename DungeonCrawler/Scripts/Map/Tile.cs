using System;

namespace DungeonCrawler
{
    public abstract class Tile : Entity
    {
        private bool isExplored;
        public bool IsExplored { get => isExplored; set => isExplored = value; }
    }
}