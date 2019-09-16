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

            for (uint currentRow = 0; currentRow < Size.Height; currentRow++)
            {
                for (uint currentColumn = 0; currentColumn < Size.Width; currentColumn++)
                {
                    if (currentColumn == 0 || currentColumn == Size.Width - 1 || currentRow == 0 || currentRow == Size.Height - 1)
                    {
                        Tiles[currentRow, currentColumn] = new Tile(TileType.Wall, currentRow, currentColumn);   //Set walls
                    }
                    else
                    {
                        Tiles[currentRow, currentColumn] = new Tile(TileType.Floor, currentRow, currentColumn);   //Set the all remaining tiles to a floor
                    }
                }
            }

            Tiles[1, 1].TileType = TileType.Player;

        }

        public void Visualize()
        {
            Console.Write("\n\n");

            for (var row = 0; row < Tiles.GetLength(0); row++)
            {
                for (var column = 0; column < Tiles.GetLength(1); column++)
                {
                    Console.Write($"\t{Tiles[row, column].Visual = Tile.UpdateTile(Tiles[row, column].TileType)}");
                }

                if(row != Tiles.GetLength(0) - 1)
                {
                    Console.Write("\n \n \n");
                } else
                {
                    Console.WriteLine();
                }
            }
        }

        

    }
}
