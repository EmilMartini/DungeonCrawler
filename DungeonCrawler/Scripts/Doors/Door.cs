﻿using System;
using System.Media;
using System.Threading;
using System.Windows;

namespace DungeonCrawler
{
    public abstract class Door : Tile, IInteractable
    {
        private Unlock unlock;
        private bool isUnlocked;
        public virtual bool Interact(Player player)
        {
            if (isUnlocked)
            {
                return true;
            }
            else
            {
                foreach (Key key in player.KeysInInventory)
                {
                    if (key.Unlock == this.unlock)
                    {
                        isUnlocked = true;
                        this.Color = ConsoleColor.White;
                        player.KeysInInventory.Remove(key);
                        return true;
                    }
                }
                return false;
            }
        }
        public Unlock Unlock
        {
            get { return unlock; }
            set { unlock = value; }
        }
        public bool IsUnlocked { get => isUnlocked; set => isUnlocked = value; }    //Fixa enkapsulering
    }
}
