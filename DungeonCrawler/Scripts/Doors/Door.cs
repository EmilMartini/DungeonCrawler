﻿using System;
namespace DungeonCrawler
{
    public abstract class Door : Tile, IInteractable
    {
        private LockColor lockColor;
        private bool isUnlocked;
        public virtual bool Interact(Player player)
        {
            if (isUnlocked)
            {
                return true;
            }
            else
            {
                foreach (Key key in player.PlayerInventory.KeyRing)
                {
                    if (key.LockColor == this.LockColor)
                    {
                        isUnlocked = true;
                        this.Color = ConsoleColor.White;
                        player.PlayerInventory.KeyRing.Remove(key);
                        return true;
                    }
                }
                return false;
            }
        }
        public LockColor LockColor
        {
            get { return lockColor; }
            set { lockColor = value; }
        }
        public bool IsUnlocked
        {
            get { return isUnlocked; }
            set { isUnlocked = value; }
        }
    }
}
