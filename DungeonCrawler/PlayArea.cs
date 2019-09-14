using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    class PlayArea
    {
        public static Tile[,] Tiles;

        public static void Init(int totalRows, int totalColumns)
        {
            Tiles = new Tile[totalRows, totalColumns];

            for (int currentRow = 0; currentRow < totalRows; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < totalColumns; currentColumn++)
                {
                    if (currentColumn == 1 && currentRow == 1)
                    { 
                        Tiles[currentRow, currentColumn] = new Tile(Tile.TileType.Floor, currentRow, currentColumn, "@");   //Set player to @ in upper left corner
                    }
                    else if (currentColumn == 0 || currentColumn == totalColumns - 1 || currentRow == 0 || currentRow == totalRows - 1)
                    {
                        Tiles[currentRow, currentColumn] = new Tile(Tile.TileType.Floor, currentRow, currentColumn, "#");   //Set walls to #
                    }
                    else if (currentColumn == 3 && currentRow == 3 || currentColumn == 6 && currentRow == 6)
                    {
                        Tiles[currentRow, currentColumn] = new Tile(Tile.TileType.Key, currentRow, currentColumn, "K");     //Set keys at specified locations
                    }
                    else if (currentColumn == 4 && currentRow == 2)
                    {
                        Tiles[currentRow, currentColumn] = new Tile(Tile.TileType.Door, currentRow, currentColumn, "D");    //Set door at specified location
                    }
                    else 
                    {
                        Tiles[currentRow, currentColumn] = new Tile(Tile.TileType.Floor, currentRow, currentColumn, "-");   //Set all available tiles to -
                    }
                }
            }

        }

        public static void Visualize(Tile[,] currentRoom)
        {
            Console.Write("\n\n");

            for (int row = 0; row < currentRoom.GetLength(0); row++)
            {
                for (int column = 0; column < currentRoom.GetLength(1); column++)
                {
                    Console.Write($"\t{currentRoom[row,column].Display}\t");
                }

                if(row != currentRoom.GetLength(0) - 1)
                {
                    Console.Write("\n \n \n");
                } else
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine($"\n\tScore: 0000 \n\tCurrent room: xxx \n\tKeys: x, x, x");
        }


        public static int GetPlayerPositionVertically()
        {
            for (int i = 0; i < Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < Tiles.GetLength(1); j++)
                {
                    if(Tiles[i,j].Display == "@")
                    {
                        return i;
                    }
                }
            }

            throw new Exception("Can't find player.");
        }
        public static int GetPlayerPositionHorizontally()
        {
            for (int i = 0; i < Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < Tiles.GetLength(1); j++)
                {
                    if(Tiles[i,j].Display == "@")
                    {
                        return j;
                    }
                }
            }

            throw new Exception("Can't find player.");
        }

    }
}
