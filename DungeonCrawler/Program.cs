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
            var mapController = new MapController(map);

            mapController.InitializeMap();

            while(true)
            {
                mapController.Render();
                playerController.CheckInput();
                Console.Clear();
            }

            
        }
    }
}
