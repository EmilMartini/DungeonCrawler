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
            var player = new Player(1, 1);
            var playerController = new PlayerController(map, player);
            var mapController = new MapController(map, player);

            mapController.InitializeMap();

            while(true)
            {
                mapController.RenderMap();
                playerController.CheckInput();
                Console.Clear();
            }

            
        }
    }
}
