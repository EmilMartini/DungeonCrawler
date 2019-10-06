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
                Point direction = new Point(0,0);
                Point noDirection = new Point(0,0);
                while (direction.Equals(noDirection))
                {
                    direction = new Point(random.Next(-1, 2), random.Next(-1, 2));
                }

                var targetEnemyPosition = new Point(gameObject.Position.Row + direction.Row, gameObject.Position.Column + direction.Column);
                
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