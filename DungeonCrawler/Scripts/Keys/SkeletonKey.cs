using System;

namespace DungeonCrawler.Keys
{
    public class SkeletonKey : Key
    {
        public SkeletonKey()
        {
            this.Unlock = Unlock.Skeleton;
            this.TileType = TileType.Key;
            this.IsExplored = false;
            this.IsEquipped = false;
            this.NumberOfUses = 2;
            this.Color = ConsoleColor.DarkGreen;
            this.Graphic = "K";
        }
    }
}
