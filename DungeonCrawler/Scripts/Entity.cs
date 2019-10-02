
using System;

namespace DungeonCrawler
{
    public abstract class Entity
    {
        private string graphic;
        private ConsoleColor color;
        private Point position;

        public string Graphic
        {
            get { return graphic; }
            protected set { graphic = value; }
        }
        public ConsoleColor Color
        {
            get { return color; }
            protected set { color = value; }
        }

        public Point Position { get => position; set => position = value; } //Fixa enkapsulering
    }
}
