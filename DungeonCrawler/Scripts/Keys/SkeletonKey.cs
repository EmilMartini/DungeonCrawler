using System;

namespace DungeonCrawler.Keys
{
    public class SkeletonKey : Key
    {
        public SkeletonKey()
        {
            this.KeyType = KeyType.Skeleton;
            this.TileType = TileType.Key;
            this.IsExplored = false;
            this.IsEquipped = false;
            this.NumberOfUses = 2;
            this.Color = ConsoleColor.DarkGreen;
            this.Graphic = "K";
        }
    }
}
