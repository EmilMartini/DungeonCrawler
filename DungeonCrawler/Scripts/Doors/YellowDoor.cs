using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class YellowDoor : Door
    {
        private readonly GameplayManager gameplayManager;
        private CurrentLevel nextLevel;
        public YellowDoor(CurrentLevel nextLevel, bool isUnlocked, GameplayManager gameplayManager)
        {
            this.Unlock = Unlock.Yellow;
            this.IsExplored = false;
            this.Color = ConsoleColor.DarkYellow;
            this.Graphic = "D";
            this.NextLevel = nextLevel;
            this.gameplayManager = gameplayManager;
            this.IsUnlocked = isUnlocked;
        }
        public CurrentLevel NextLevel { get => nextLevel; set => nextLevel = value; }

        public override bool Interact(Player player)
        {
            if (IsUnlocked)
            {
                ChangeLevel();
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
                        ChangeLevel();
                        return true;
                    }
                }
                return false;
            }
        }
        private void ChangeLevel()
        {
            gameplayManager.NextLevel = this.NextLevel;
            gameplayManager.CurrentState = State.ExitLevel;
        }
    }
}
