using DungeonCrawler.Doors;
using DungeonCrawler.Keys;

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
                            Levels[i].InitialLayout[row, column] = new Wall(true);
                        }
                        else
                        {
                            Levels[i].InitialLayout[row, column] = new Floor();
                        }
                    }
                }

            }

            //Level one
            //Hardcoded walls
            Levels[0].InitialLayout[14, 1] = new Wall(false);
            Levels[0].InitialLayout[14, 2] = new Wall(false);
            Levels[0].InitialLayout[14, 3] = new Wall(false);
            Levels[0].InitialLayout[14, 4] = new Wall(false);
            Levels[0].InitialLayout[14, 5] = new Wall(false);
            Levels[0].InitialLayout[14, 6] = new Wall(false);
            Levels[0].InitialLayout[14, 8] = new Wall(false);
            Levels[0].InitialLayout[14, 9] = new Wall(false);
            Levels[0].InitialLayout[15, 9] = new Wall(false);
            Levels[0].InitialLayout[16, 9] = new Wall(false);
            Levels[0].InitialLayout[17, 9] = new Wall(false);
            Levels[0].InitialLayout[18, 9] = new Wall(false);
            Levels[0].InitialLayout[19, 9] = new Wall(false);
            Levels[0].InitialLayout[20, 9] = new Wall(false);
            Levels[0].InitialLayout[21, 9] = new Wall(false);
            Levels[0].InitialLayout[22, 9] = new Wall(false);
            Levels[0].InitialLayout[23, 9] = new Wall(false);

            Levels[0].InitialLayout[1, 15] = new Wall(false);
            Levels[0].InitialLayout[2, 15] = new Wall(false);
            Levels[0].InitialLayout[3, 15] = new Wall(false);
            Levels[0].InitialLayout[4, 15] = new Wall(false);
            Levels[0].InitialLayout[5, 15] = new Wall(false);
            Levels[0].InitialLayout[6, 15] = new Wall(false);
            Levels[0].InitialLayout[7, 15] = new Wall(false);
            Levels[0].InitialLayout[8, 15] = new Wall(false);
            Levels[0].InitialLayout[9, 15] = new Wall(false);
            Levels[0].InitialLayout[9, 16] = new Wall(false);
            Levels[0].InitialLayout[9, 17] = new Wall(false);
            Levels[0].InitialLayout[9, 18] = new Wall(false);
            Levels[0].InitialLayout[9, 19] = new Wall(false);
            Levels[0].InitialLayout[9, 21] = new Wall(false);
            Levels[0].InitialLayout[9, 22] = new Wall(false);
            Levels[0].InitialLayout[9, 23] = new Wall(false);
            Levels[0].InitialLayout[9, 24] = new Wall(false);

            //Hardcoded doors
            Levels[0].InitialLayout[14, 7] = new BlueDoor();
            Levels[0].InitialLayout[9, 20] = new PurpleDoor();

            //Hardcoded keys
            Levels[0].InitialLayout[6, 2] = new PurpleKey();
            Levels[0].InitialLayout[2,20] = new BlueKey();
            Levels[0].InitialLayout[3, 20] = new TrapDoor();         
        }
    }
}
