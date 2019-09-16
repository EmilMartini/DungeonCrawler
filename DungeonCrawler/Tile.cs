using System;

namespace DungeonCrawler
{
    public class Tile
    {
        public TileType TileType;

        public uint TileHorizontal;
        public uint TileVertical;
        public string Visual;

        public Tile(TileType assignedTileType, uint vertical, uint horizontal)
        {
            TileType = assignedTileType;
            TileVertical = vertical;
            TileHorizontal = horizontal;
            Visual = UpdateTile(assignedTileType);
        }

        public static string UpdateTile(TileType assignedTileType)
        {
            switch (assignedTileType)
            {
                case TileType.Wall:
                    return "#";
                case TileType.Floor:
                    return "-";
                case TileType.Key:
                    return "K";
                case TileType.Door:
                    return "D";
                case TileType.Monster:
                    return "M";
                case TileType.Player:
                    return "@";
                default:
                    throw new Exception($"Can't update {assignedTileType}.");
            }
        }
    }
}