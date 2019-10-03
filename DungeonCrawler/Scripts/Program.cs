using System;

namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            GameplayManager gameplayManager = new GameplayManager();
            while (gameplayManager.CurrentState != State.ExitGame)
            {              
                gameplayManager.RunState();
            }
            Console.Clear();
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }

    }
}