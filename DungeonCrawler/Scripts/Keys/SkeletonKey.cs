using System;
namespace DungeonCrawler
{
    public class SkeletonKey : Key
    {
        public SkeletonKey(int x, int y) : base(x,y)
        {
            LockColor = LockColor.Skeleton;
            NumberOfUses = 2;
            Color = ConsoleColor.DarkGreen;
            Graphic = "K";
        }
    }
}
