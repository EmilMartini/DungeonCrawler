using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Enemy : GameObject, IInteractable
    {
        public Enemy(int startRow, int startColumn)
        {
            this.Graphic = "X";
            this.Color = ConsoleColor.Red;
            Position = new Point(startRow, startColumn);
        }
        public bool Interact()
        {
            Player.EnemiesInteractedWith++;
            return true;
        }
    }
}
