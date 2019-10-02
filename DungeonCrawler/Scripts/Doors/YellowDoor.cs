using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class YellowDoor : Door
    {
        private readonly StateMachine stateMachine;
        private CurrentLevel nextLevel;
        public YellowDoor(CurrentLevel nextLevel, bool isUnlocked, StateMachine stateMachine)
        {
            this.Unlock = Unlock.Yellow;
            this.IsExplored = false;
            this.Color = ConsoleColor.DarkYellow;
            this.Graphic = "D";
            this.NextLevel = nextLevel;
            this.stateMachine = stateMachine;
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
            stateMachine.NextLevel = this.NextLevel;
            stateMachine.CurrentState = StateMachine.State.ExitLevel;
        }
    }
}
