using System;
using System.Linq;

namespace DungeonCrawler
{
    public class EnemyController
    {
        private readonly Random random = new Random();

        public void MoveEnemies(GameplayManager gameplayManager)
        {
            var index = 0;
            var currentLevel = gameplayManager.Levels[gameplayManager.CurrentLevel];
            foreach (var gameObject in currentLevel.ActiveGameObjects.OfType<Enemy>())
            {
                int row = 0, column = 0;
                while (row == 0 && column == 0)
                {
                    row = this.random.Next(-1, 2);
                    column = this.random.Next(-1, 2);
                }

                var targetEnemyPosition = new Point(gameObject.Position.Row + row, gameObject.Position.Column + column);
                
                if (!PathAvailable(targetEnemyPosition, currentLevel))
                    continue;
                
                currentLevel.PreviousEnemyPositions[index] =
                    new Point(gameObject.Position.Row, gameObject.Position.Column);
                
                gameObject.Position = targetEnemyPosition;
                index++;
            }
        }

        private bool PathAvailable(Point targetEnemyPosition, Level currentLevel)
        {
            var activeGameObjects = currentLevel.ActiveGameObjects;
            var targetTile = currentLevel.Layout[targetEnemyPosition.Row, targetEnemyPosition.Column];
            foreach (var gameObject in activeGameObjects)
            {
                if (gameObject is Enemy)
                    continue;

                if (gameObject.Position.Equals(targetEnemyPosition))
                    return false;
            }

            return !(targetTile is Door) && !(targetTile is Wall);
        }
    }
}