using System;


namespace DungeonCrawler
{
    public class Map
    {
        public Tile[,] Tiles;
        public Size Size;

        public Map(Size size)
        {
            Size = size;
            InitializeMap();
        }


        private void InitializeMap()
        {
            Tiles = new Tile[Size.Height, Size.Width];

            for (var currentRow = 0; currentRow < Size.Height; currentRow++)
            {
                for (var currentColumn = 0; currentColumn < Size.Width; currentColumn++)
                {
                    if (currentColumn == 1 && currentRow == 1)
                    { 
                        Tiles[currentRow, currentColumn] = new Tile(TileType.Floor, currentRow, currentColumn, "@");   //Set player to @ in upper left corner
                    }
                    else if (currentColumn == 0 || currentColumn == Size.Width - 1 || currentRow == 0 || currentRow == Size.Height - 1)
                    {
                        Tiles[currentRow, currentColumn] = new Tile(TileType.Floor, currentRow, currentColumn, "#");   //Set walls to #
                    }
                    else if (currentColumn == 3 && currentRow == 3 || currentColumn == 6 && currentRow == 6)
                    {
                        Tiles[currentRow, currentColumn] = new Tile(TileType.Key, currentRow, currentColumn, "K");     //Set keys at specified locations
                    }
                    else if (currentColumn == 4 && currentRow == 2)
                    {
                        Tiles[currentRow, currentColumn] = new Tile(TileType.Door, currentRow, currentColumn, "D");    //Set door at specified location
                    }
                    else 
                    {
                        Tiles[currentRow, currentColumn] = new Tile(TileType.Floor, currentRow, currentColumn, "-");   //Set all available tiles to -
                    }
                }
            }

        }

        public void Visualize()
        {
            Console.Write("\n\n");

            for (var row = 0; row < Tiles.GetLength(0); row++)
            {
                for (var column = 0; column < Tiles.GetLength(1); column++)
                {
                    Console.Write($"\t{Tiles[row,column].Display}");
                }

                if(row != Tiles.GetLength(0) - 1)
                {
                    Console.Write("\n \n \n");
                } else
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine($"\n\tScore: 0000 \n\tCurrent room: xxx \n\tKeys: x, x, x");
        }


        public int GetPlayerPositionVertically()
        {
            for (var row = 0; row < Tiles.GetLength(0); row++)
            {
                for (var column = 0; column < Tiles.GetLength(1); column++)
                {
                    if(Tiles[row,column].Display == "@")
                    {
                        return row;
                    }
                }
            }

            throw new Exception("Can't find player.");
        }
        public int GetPlayerPositionHorizontally()
        {
            for (var row = 0; row < Tiles.GetLength(0); row++)
            {
                for (var column = 0; column < Tiles.GetLength(1); column++)
                {
                    if(Tiles[row,column].Display == "@")
                    {
                        return column;
                    }
                }
            }

            throw new Exception("Can't find player.");
        }

    }
}
