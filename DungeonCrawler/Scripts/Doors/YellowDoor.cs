using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class YellowDoor : Door
    {
        private CurrentLevel nextLevel;
        public YellowDoor(CurrentLevel nextLevel, bool isUnlocked)
        {
            this.Unlock = Unlock.Yellow;
            this.IsExplored = false;
            this.Graphic = "D";
            this.NextLevel = nextLevel;
            this.IsUnlocked = isUnlocked;
            if (!isUnlocked)
            {
                this.Color = ConsoleColor.DarkYellow;
            } else
            {
                this.Color = ConsoleColor.White;
            }
        }
        public CurrentLevel NextLevel { get => nextLevel; set => nextLevel = value; }

        public override bool Interact(Player player)
        {
            if (IsUnlocked)
            {
                return true;
            }
            else
            {
                foreach (Key key in player.KeysInInventory)
                {
                    if (key.Unlock == this.Unlock)
                    {
                        IsUnlocked = true;
                        player.KeysInInventory.Remove(key);
                        return true;
                    }
                }
                return false;
            }
        }

    }
}
