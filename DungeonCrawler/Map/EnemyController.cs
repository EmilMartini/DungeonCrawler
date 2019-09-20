using System;

namespace DungeonCrawler
{
    internal class EnemyController
    {
        Random rnd = new Random();
        public Point currentEnemyPosition;
        private readonly Level level;
        private readonly MapController mapController;

        public EnemyController(Level level, MapController mapController)
        {
            this.level = level ?? throw new ArgumentNullException(nameof(level));
            this.mapController = mapController ?? throw new ArgumentNullException(nameof(mapController));
        }

        public void Move()
        {
            for (int i = 0; i < level.Enemies.Length; i++)
            {
                int row = 0, column = 0;

                while (row == 0 && column == 0)
                {
                    row = rnd.Next(-1, 2);
                    column = rnd.Next(-1, 2);
                }

                currentEnemyPosition = new Point(currentEnemyPosition.row + row, currentEnemyPosition.column + column);

                if (level.InitialLayout[currentEnemyPosition.row, currentEnemyPosition.column].TileType != TileType.Wall)
                {
                    mapController.UpdateMonsterPosition(level.Enemies[i], currentEnemyPosition);
                }
            }     
        }

        
    }
}