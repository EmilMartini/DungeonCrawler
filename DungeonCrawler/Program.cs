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
            Room.Init(10,10);
            Room.VisualizeRoom();
            Console.ReadKey(true);
        }
    }
}
