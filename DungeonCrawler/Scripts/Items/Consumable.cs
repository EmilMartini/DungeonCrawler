using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class Consumable : GameObject
    {
        private uint numberOfUses;
        public uint NumberOfUses
        {
            get { return numberOfUses; }
            set { numberOfUses = value; }
        }
    }
}
