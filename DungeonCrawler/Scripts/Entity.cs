
using System;

namespace DungeonCrawler
{
    public abstract class Entity
    {
        private Point position;
        private string graphic;
        private bool isExplored;
        private ConsoleColor color;

        public bool IsExplored { get => isExplored; set => isExplored = value; }
        public string Graphic { get => graphic; set => graphic = value; }
        public Point Position { get => position; set => position = value; }

        public ConsoleColor Color { get => color; set => color = value; }

        //This class should hold a "Color" field,
    }
}
