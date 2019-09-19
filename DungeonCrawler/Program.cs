using System;
namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var PlayerStartPosition = new Point(1, 1);
            var map = new Map(new Size(25, 25));
            var player = new Player(PlayerStartPosition);
            var mapController = new MapController(map, player);
            var playerController = new PlayerController(map, player, mapController);

            mapController.InitializeMap(player.Position);
            mapController.DisplayInitialMap();
            mapController.GetPointsToExplore(PlayerStartPosition);
            mapController.RenderMap();


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
