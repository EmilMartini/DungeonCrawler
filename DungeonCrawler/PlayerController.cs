using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class PlayerController
    {
        public static void CheckInput()
        {
            ConsoleKeyInfo input = Console.ReadKey();

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

        public static void MovePlayer(int directionHorizontal, int directionVertical)
        {
            int _currentPlayerPositionVertical = PlayArea.GetPlayerPositionVertically();
            int _currentPlayerPositionHorizontal = PlayArea.GetPlayerPositionHorizontally();

            if(PlayArea.Tiles[_currentPlayerPositionVertical + directionVertical, _currentPlayerPositionHorizontal + directionHorizontal].Display != "#")
            {
                PlayArea.Tiles[_currentPlayerPositionVertical, _currentPlayerPositionHorizontal].Display = "-";
                PlayArea.Tiles[_currentPlayerPositionVertical + directionVertical, _currentPlayerPositionHorizontal + directionHorizontal].Display = "@";
            }
            
        }
    }
}
