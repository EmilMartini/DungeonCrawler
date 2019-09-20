using System;
namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            var levelLayout = new LevelLayout(); //TODO: fix level loader
            var player = new Player(levelLayout.Levels[0].PlayerStartingTile);

            var mapController = new MapController(levelLayout.Levels[0], player);
            var levelLoader = new LevelLoader(levelLayout.Levels, mapController);

            var playerController = new PlayerController(levelLayout.Levels[0], player, mapController);

            mapController.InitializeMap(player.Position);
            mapController.DisplayInitialMap();
            mapController.GetPointsToExplore(levelLayout.Levels[0].PlayerStartingTile);
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
