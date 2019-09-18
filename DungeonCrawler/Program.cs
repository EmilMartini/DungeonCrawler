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
            Point PlayerStartPosition = new Point(9, 12);

            var map = new Map(new Size(14, 14));
            var player = new Player(PlayerStartPosition);
            var mapController = new MapController(map, player);
            var playerController = new PlayerController(map, player, mapController);


            mapController.InitializeMap(player.Position);

            while(true)
            {
                mapController.RenderMap();
                playerController.CheckInput();
                Console.Clear();
            }

            
        }
    }
}
