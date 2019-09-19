﻿using System;
namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {

            var levelLayout = new LevelLayout();
            var player = new Player(levelLayout.Levels[0].PlayerStartingTile);

            var levelLoader = new LevelLoader(levelLayout.Levels);
            var mapController = new MapController(levelLayout.Levels[0], player);

            var playerController = new PlayerController(levelLayout.Levels[0], player, mapController);

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
