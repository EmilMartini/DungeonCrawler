using System;

namespace DungeonCrawler
{
    public abstract class Entity
    {
        public string Graphic { get; protected set; }
        public ConsoleColor Color { get; protected set; }
        public Point Position { get; set; }
    }
}
