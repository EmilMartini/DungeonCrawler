using System;


namespace DungeonCrawler
{
    public class PlayerController
    {
        private readonly Map _map;

        public PlayerController(Map map)
        {
            _map = map ?? throw new ArgumentNullException(nameof(map));
        }

        public void CheckInput()
        {
            var input = Console.ReadKey();

            switch(input.KeyChar)
            {
                case 'w':
                    MovePlayer(0, -1);
                    break;
                case 'a':
                    MovePlayer(-1, 0);
                    break;
                case 's':
                    MovePlayer(0, 1);
                    break;
                case 'd':
                    MovePlayer(1, 0);
                    break;
                default:
                    break;
            }

        }

        public void MovePlayer(int directionHorizontal, int directionVertical)
        {
            var currentPlayerPositionVertical = _map.GetPlayerPositionVertically();
            var currentPlayerPositionHorizontal = _map.GetPlayerPositionHorizontally();

            if(_map.Tiles[currentPlayerPositionVertical + directionVertical, currentPlayerPositionHorizontal + directionHorizontal].Display != "#")
            {
                _map.Tiles[currentPlayerPositionVertical, currentPlayerPositionHorizontal].Display = "-";
                _map.Tiles[currentPlayerPositionVertical + directionVertical, currentPlayerPositionHorizontal + directionHorizontal].Display = "@";
            }
            
        }
    }
}
