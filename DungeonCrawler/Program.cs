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
            Point PlayerStartPosition = new Point(4, 4);

            var map = new Map(new Size(9, 9));
            var player = new Player(PlayerStartPosition);
            var playerController = new PlayerController(map, player);
            var mapController = new MapController(map, player);


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
