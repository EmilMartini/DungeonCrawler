using System;
using DungeonCrawler.Doors;
using DungeonCrawler.Keys;
using DungeonCrawler.Scripts.Map;

namespace DungeonCrawler
{
    public class LevelLayout
    {
        public Level[] Levels = new Level[3];
        private Point[] spawnPoints = new Point[3];

        readonly static Point level1SpawnPoint = new Point(1, 1);
        readonly static Point level2SpawnPoint = new Point(16, 7);
        readonly static Point level3SpawnPoint = new Point(1, 1);
        readonly Level level1 = new Level(new Size(25, 25), level1SpawnPoint, 8);
        readonly Level level2 = new Level(new Size(18, 18), level2SpawnPoint, 0);
        readonly Level level3 = new Level(new Size(24, 14), level3SpawnPoint, 10);

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
            SetLevelOneLayout();
            SetLevelTwoLayout();

        }
        private void SetLevelOneLayout()
        {
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

            //Hardcoded doors
            Levels[0].InitialLayout[14, 7] = new BlueDoor();
            Levels[0].InitialLayout[9, 20] = new PurpleDoor();

            //Hardcoded keys
            Levels[0].InitialLayout[6, 2] = new PurpleKey();
            Levels[0].InitialLayout[2, 18] = new BlueKey();

            //Hardcoded water
            Levels[0].InitialLayout[13, 1] = new Water();
            Levels[0].InitialLayout[13, 2] = new Water();
            Levels[0].InitialLayout[13, 3] = new Water();
            Levels[0].InitialLayout[13, 4] = new Water();
            Levels[0].InitialLayout[13, 5] = new Water();
            Levels[0].InitialLayout[13, 6] = new Water();
            Levels[0].InitialLayout[13, 8] = new Water();
            Levels[0].InitialLayout[13, 9] = new Water();
        }
        private void SetLevelTwoLayout()
        {
            //readonly static Point level2SpawnPoint = new Point(17, 7);
            //Level one
            //Hardcoded walls
            Levels[1].InitialLayout[6, 16] = new Wall(false);
            Levels[1].InitialLayout[8, 16] = new Wall(false);
            Levels[1].InitialLayout[12, 16] = new Wall(false);
            Levels[1].InitialLayout[15, 16] = new Wall(false);
            Levels[1].InitialLayout[16, 16] = new Wall(false);


            Levels[1].InitialLayout[6, 15] = new Wall(false);
            Levels[1].InitialLayout[8, 15] = new Wall(false);
            Levels[1].InitialLayout[12, 15] = new Wall(false);
            Levels[1].InitialLayout[14, 15] = new Wall(false);


            Levels[1].InitialLayout[6, 14] = new Wall(false);
            Levels[1].InitialLayout[8, 14] = new Wall(false);
            Levels[1].InitialLayout[9, 14] = new Wall(false);
            Levels[1].InitialLayout[10, 14] = new Wall(false);
            Levels[1].InitialLayout[11, 14] = new Wall(false);
            Levels[1].InitialLayout[12, 14] = new Wall(false);
            Levels[1].InitialLayout[13, 14] = new Wall(false);
            Levels[1].InitialLayout[14, 14] = new Wall(false);
            Levels[1].InitialLayout[16, 14] = new Wall(false);
            Levels[1].InitialLayout[17, 14] = new Wall(false);


            Levels[1].InitialLayout[6, 13] = new Wall(false);

            Levels[1].InitialLayout[8, 12] = new Wall(false);
            Levels[1].InitialLayout[6, 12] = new Wall(false);
            Levels[1].InitialLayout[9, 12] = new Wall(false);
            Levels[1].InitialLayout[11, 12] = new Wall(false);
            Levels[1].InitialLayout[12, 12] = new Wall(false);
            Levels[1].InitialLayout[13, 12] = new Wall(false);
            Levels[1].InitialLayout[14, 12] = new Wall(false);
            Levels[1].InitialLayout[15, 12] = new Wall(false);
            Levels[1].InitialLayout[16, 12] = new Wall(false);

            Levels[1].InitialLayout[6, 11] = new Wall(false);
            Levels[1].InitialLayout[8, 11] = new Wall(false);
            Levels[1].InitialLayout[9, 11] = new Wall(false);
            Levels[1].InitialLayout[11, 11] = new Wall(false);
            Levels[1].InitialLayout[16, 11] = new Wall(false);

            Levels[1].InitialLayout[8, 10] = new Wall(false);
            Levels[1].InitialLayout[11, 10] = new Wall(false);
            Levels[1].InitialLayout[13, 10] = new Wall(false);
            Levels[1].InitialLayout[14, 10] = new Wall(false);
            Levels[1].InitialLayout[16, 10] = new Wall(false);


            Levels[1].InitialLayout[6, 9] = new Wall(false);
            Levels[1].InitialLayout[8, 9] = new Wall(false);
            Levels[1].InitialLayout[9, 9] = new Wall(false);
            Levels[1].InitialLayout[11, 9] = new Wall(false);
            Levels[1].InitialLayout[14, 9] = new Wall(false);
            Levels[1].InitialLayout[15, 9] = new Wall(false);
            Levels[1].InitialLayout[16, 9] = new Wall(false);

            Levels[1].InitialLayout[6, 8] = new Wall(false);
            Levels[1].InitialLayout[8, 8] = new Wall(false);
            Levels[1].InitialLayout[9, 8] = new Wall(false);
            Levels[1].InitialLayout[11, 8] = new Wall(false);
            Levels[1].InitialLayout[12, 8] = new Wall(false);
            Levels[1].InitialLayout[14, 8] = new Wall(false);

            Levels[1].InitialLayout[6, 7] = new Wall(false);
            Levels[1].InitialLayout[8, 7] = new Wall(false);
            Levels[1].InitialLayout[9, 7] = new Wall(false);
            Levels[1].InitialLayout[12, 7] = new Wall(false);
            Levels[1].InitialLayout[14, 7] = new Wall(false);
            Levels[1].InitialLayout[15, 7] = new Wall(false);
            Levels[1].InitialLayout[16, 7] = new Wall(false);

            Levels[1].InitialLayout[8, 6] = new Wall(false);
            Levels[1].InitialLayout[9, 6] = new Wall(false);
            Levels[1].InitialLayout[11, 6] = new Wall(false);
            Levels[1].InitialLayout[12, 6] = new Wall(false);
            Levels[1].InitialLayout[14, 6] = new Wall(false);
            Levels[1].InitialLayout[16, 6] = new Wall(false);

            Levels[1].InitialLayout[6, 5] = new Wall(false);
            Levels[1].InitialLayout[8, 5] = new Wall(false);
            Levels[1].InitialLayout[11, 5] = new Wall(false);
            Levels[1].InitialLayout[14, 5] = new Wall(false);

            Levels[1].InitialLayout[6, 4] = new Wall(false);
            Levels[1].InitialLayout[8, 4] = new Wall(false);
            Levels[1].InitialLayout[10, 4] = new Wall(false);
            Levels[1].InitialLayout[11, 4] = new Wall(false);
            Levels[1].InitialLayout[12, 4] = new Wall(false);
            Levels[1].InitialLayout[16, 4] = new Wall(false);

            Levels[1].InitialLayout[10, 3] = new Wall(false);
            Levels[1].InitialLayout[14, 3] = new Wall(false);
            Levels[1].InitialLayout[16, 3] = new Wall(false);

            Levels[1].InitialLayout[6, 2] = new Wall(false);
            Levels[1].InitialLayout[8, 2] = new Wall(false);
            Levels[1].InitialLayout[10, 2] = new Wall(false);
            Levels[1].InitialLayout[12, 2] = new Wall(false);
            Levels[1].InitialLayout[14, 2] = new Wall(false);
            Levels[1].InitialLayout[16, 2] = new Wall(false);

            Levels[1].InitialLayout[6, 1] = new Wall(false);
            Levels[1].InitialLayout[12, 1] = new Wall(false);
            Levels[1].InitialLayout[16, 1] = new Wall(false);

            //    //Hardcoded doors
            //    //Levels[0].InitialLayout[14, 7] = new BlueDoor();
            //    //Levels[0].InitialLayout[9, 20] = new PurpleDoor();

            //    ////Hardcded keys
            //    //Levels[0].InitialLayout[6, 2] = new PurpleKey();
            //    //Levels[0].InitialLayout[2, 18] = new BlueKey();
            }
        }
}
            
