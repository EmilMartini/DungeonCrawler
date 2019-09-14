﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    class Room
    {
        public static Tile[,] Tiles;

        public static void Init(int totalRows, int totalColumns)
        {
            Tiles = new Tile[totalRows, totalColumns];

            for (int currentRow = 0; currentRow < totalRows; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < totalColumns; currentColumn++)
                {
                    if(currentColumn == 0 || currentColumn == totalColumns - 1 || currentRow == 0 || currentRow ==  totalRows - 1)
                    {
                        Tiles[currentRow, currentColumn] = new Tile(Tile.TileType.Floor, currentRow, currentColumn, "#");
                    } else
                    {
                        Tiles[currentRow, currentColumn] = new Tile(Tile.TileType.Floor, currentRow, currentColumn, "-");
                    }
                }
            }

        }

        public static void VisualizeRoom()
        {
            for (int row = 0; row < Tiles.GetLength(0); row++)
            {
                for (int column = 0; column < Tiles.GetLength(1); column++)
                {
                    Console.Write($"{Tiles[row,column].Display} \t");
                }
                Console.Write("\n \n");
            }
        }
    }
}
