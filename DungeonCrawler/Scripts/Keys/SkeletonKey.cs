using System;
namespace DungeonCrawler
{
    public class SkeletonKey : Key
    {
        public SkeletonKey(int x, int y) : base(x,y)
        {
            this.LockColor = LockColor.Skeleton;
            this.NumberOfUses = 2;
            this.Color = ConsoleColor.DarkGreen;
            this.Graphic = "K";
        }
    }
}
