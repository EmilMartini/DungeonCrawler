using System;

namespace DungeonCrawler
{
    public class Tile
    {
        public TileType TileType;

        public int TileHorizontal;
        public int TileVertical;
        public string Visual;

        public Tile(TileType assignedTileType, int vertical, int horizontal)
        {
            TileType = assignedTileType;
            TileVertical = vertical;
            TileHorizontal = horizontal;
            Visual = _initializeTileVisual(assignedTileType);
        }

        private string _initializeTileVisual(TileType assignedTileType)
        {
            switch (assignedTileType)
            {
                case TileType.Floor:
                    return "-";
                case TileType.Wall:
                    return "#";
                default:
                    throw new Exception($"Can't visualize {assignedTileType}.");
            }
        }

    }
}