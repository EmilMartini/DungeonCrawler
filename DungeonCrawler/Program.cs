using System;
namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var PlayerStartPosition = new Point(9, 12);
            var map = new Map(new Size(14, 14));
            var player = new Player(PlayerStartPosition);
            var mapController = new MapController(map, player);
            var playerController = new PlayerController(map, player, mapController);

            mapController.InitializeMap(player.Position);
            mapController.DisplayInitialMap();
            var standardOutputWriter = Console.Out;
            var consoleOutputFilter = new ConsoleOutputFilter();

            while(true)
            {
                Console.SetOut(consoleOutputFilter);
                playerController.CheckInput();
                Console.SetOut(standardOutputWriter);
                mapController.RenderMap();
            }            
        }
    }
}
