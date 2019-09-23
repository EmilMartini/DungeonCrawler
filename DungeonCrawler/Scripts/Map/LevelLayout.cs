using System;

namespace DungeonCrawler
{
    public class LevelLayout
    {
        public Level[] Levels = new Level[3];
        private Point[] spawnPoints = new Point[3];

        readonly static Point level1SpawnPoint = new Point(1, 1);
        readonly static Point level2SpawnPoint = new Point(17, 17);
        readonly static Point level3SpawnPoint = new Point(1, 1);
        readonly Level level1 = new Level(new Size(25, 25), level1SpawnPoint, 8, 2, 2);
        readonly Level level2 = new Level(new Size(18, 18), level2SpawnPoint, 5, 1, 1);
        readonly Level level3 = new Level(new Size(24, 14), level3SpawnPoint, 10,3, 3);

        public LevelLayout()
        {
            Levels[0] = level1;
            Levels[1] = level2;
            Levels[2] = level3;

            spawnPoints[0] = level1SpawnPoint;
            spawnPoints[1] = level2SpawnPoint;
            spawnPoints[2] = level3SpawnPoint;
        }
        public void InitializeLevels()
        {
            for (int i = 0; i < Levels.Length; i++)
            {
                Levels[i].InitialLayout = new Tile[Levels[i].Size.Height, Levels[i].Size.Width];
                Levels[i].ExploredLayout = new Tile[Levels[i].Size.Height, Levels[i].Size.Width];
                Levels[i].Enemies = new Enemy[Levels[i].NumberOfEnemies];
                Levels[i].PreviousEnemyPositions = new Point[Levels[i].Enemies.Length];

                for (int row = 0; row < Levels[i].Size.Height; row++)
                {
                    for (int column = 0; column < Levels[i].Size.Width; column++)
                    {
                        if (column == 0 || column == Levels[i].Size.Width - 1 || row == 0 || row == Levels[i].Size.Height - 1)
                        {
                            Levels[i].InitialLayout[row, column] = new Wall();
                        }
                        else
                        {
                            Levels[i].InitialLayout[row, column] = new Floor();
                        }
                    }
                }
            }
        }
    }
}
