using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class Door : Tile, IInteractable
    {
        private DoorType doorType;

        public DoorType DoorType
        {
            get { return doorType; }
            set { doorType = value; }
        }

        public void Interact()
        {
            throw new NotImplementedException();
        }
    }
}
