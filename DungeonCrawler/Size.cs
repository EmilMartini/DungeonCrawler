using System;

namespace DungeonCrawler
{
    public struct Size
    {
        public Size(uint width, uint height)
        {
            Width = width;
            Height = height;
        }
        public readonly uint Width;
        public readonly uint Height;

    }
}