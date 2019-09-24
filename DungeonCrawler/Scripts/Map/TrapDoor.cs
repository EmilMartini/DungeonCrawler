﻿using System;

namespace DungeonCrawler
{
    public class TrapDoor : Tile, IInteractable
    {
        public TrapDoor()
        {
            this.TileType = TileType.TrapDoor;
            this.IsExplored = false;
            this.Color = ConsoleColor.DarkGray;
            this.Graphic = ".";
        }

        public bool Interact()
        {

            return true;
        }
    }
}