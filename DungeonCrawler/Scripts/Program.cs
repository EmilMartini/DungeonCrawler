using System;
using System.Threading;

namespace DungeonCrawler
{
    class Program
    {
        private static bool exitGame;   //Fixa riktigt wincondition istället för bool

        static void Main(string[] args)
        {
            GameplayManager gameplayManager = new GameplayManager();
            while (!exitGame)
            {              
                gameplayManager.RunState();
            }        
        }

    }
}