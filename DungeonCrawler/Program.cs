using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var map = new Map(new Size(9, 9));
            var player = new Player();
            var playerController = new PlayerController(map, player);

            while(true)
            {
                map.Visualize();
                playerController.CheckInput();
                Console.Clear();
            }

            
        }
    }
}
