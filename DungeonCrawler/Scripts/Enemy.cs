using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Enemy : GameObject, IInteractable
    {
        public Enemy(Point spawnPoint)
        {
            Graphic = "X";
            Color = ConsoleColor.Red;
            Position = spawnPoint;
        }
        public bool Interact(Player player)
        {
            player.EnemiesInteractedWith++;
            return true;
        }
    }
}
