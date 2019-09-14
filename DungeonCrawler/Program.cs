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
            PlayArea.Init(9,9);

            while(true)
            {
                PlayArea.Visualize();
                PlayerController.CheckInput();
                Console.Clear();
            }
        }
    }
}
