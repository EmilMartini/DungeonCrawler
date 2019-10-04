using System;
namespace DungeonCrawler
{
    public class YellowDoor : Door
    {
        private CurrentLevel nextLevel;
        public YellowDoor(bool isUnlocked)
        {
            this.LockColor = LockColor.Yellow;
            this.IsExplored = false;
            this.Color = ConsoleColor.DarkYellow;
            this.Graphic = "D";
            this.NextLevel = nextLevel;
            this.IsUnlocked = isUnlocked;
        }
        public CurrentLevel NextLevel { get => nextLevel; set => nextLevel = value; }
        //public override bool Interact(Player player)
        //{
        //    if (IsUnlocked)
        //    {
        //        ChangeLevel();
        //        return true;
        //    }
        //    else
        //    {
        //        foreach (Key key in player.Inventory.KeyRing)
        //        {
        //            if (key.LockColor == this.LockColor)
        //            {
        //                IsUnlocked = true;
        //                player.Inventory.KeyRing.Remove(key);
        //                ChangeLevel();
        //                return true;
        //            }
        //        }
        //        return false;
        //    }
        //}
    }
}
