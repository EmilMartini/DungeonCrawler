using System;
using DungeonCrawler.Doors;
using DungeonCrawler.Keys;
using DungeonCrawler.Scripts.Map;

namespace DungeonCrawler
{
    public class LevelLayout
    {
        private Level[] Levels = new Level[3];
        private Point[] spawnPoints = new Point[3];

        readonly static Point level1SpawnPoint = new Point(1, 1);
        readonly static Point level2SpawnPoint = new Point(14, 8);
        readonly static Point level3SpawnPoint = new Point(1, 1);
        readonly Level level1 = new Level(new Size(25, 25), level1SpawnPoint, 8);
        readonly Level level2 = new Level(new Size(18, 18), level2SpawnPoint, 0);
        readonly Level level3 = new Level(new Size(23, 13), level3SpawnPoint, 10);

        public LevelLayout(StateMachine stateMachine)
        {
            Levels[0] = level1;
            Levels[1] = level2;
            Levels[2] = level3;

            spawnPoints[0] = level1SpawnPoint;
            spawnPoints[1] = level2SpawnPoint;
            spawnPoints[2] = level3SpawnPoint;
            stateMachine.Levels = Levels;
        } 
        public void SetLevelOneLayout()
        {
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
            Levels[0].InitialLayout[23, 3] = new Wall(false);
            Levels[0].InitialLayout[23, 5] = new Wall(false);
            //Hardcoded doors
            Levels[0].InitialLayout[14, 7] = new BlueDoor();
            Levels[0].InitialLayout[9, 20] = new PurpleDoor();
            Levels[0].InitialLayout[23, 4] = new YellowDoor(CurrentLevel.LevelTwo, false);
            //Hardcoded keys
            Levels[0].InitialLayout[6, 2] = new PurpleKey();
            Levels[0].InitialLayout[2, 18] = new BlueKey();
            Levels[0].InitialLayout[22, 22] = new YellowKey();
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
        public void SetLevelTwoLayout()
        {
            //Hardcoded walls
            Levels[1].InitialLayout[5, 16] = new Wall(false);
            Levels[1].InitialLayout[7, 16] = new Wall(false);
            Levels[1].InitialLayout[11, 16] = new Wall(false);
            Levels[1].InitialLayout[15, 16] = new Wall(false);
            Levels[1].InitialLayout[16, 16] = new Wall(false);

            Levels[1].InitialLayout[1, 15] = new Wall(false);
            Levels[1].InitialLayout[2, 15] = new Wall(false);
            Levels[1].InitialLayout[3, 15] = new Wall(false);
            Levels[1].InitialLayout[5, 15] = new Wall(false);
            Levels[1].InitialLayout[7, 15] = new Wall(false);
            Levels[1].InitialLayout[11, 15] = new Wall(false);
            Levels[1].InitialLayout[13, 15] = new Wall(false);

            Levels[1].InitialLayout[5, 14] = new Wall(false);
            Levels[1].InitialLayout[7, 14] = new Wall(false);
            Levels[1].InitialLayout[8, 14] = new Wall(false);
            Levels[1].InitialLayout[10, 14] = new Wall(false);
            Levels[1].InitialLayout[11, 14] = new Wall(false);
            Levels[1].InitialLayout[12, 14] = new Wall(false);
            Levels[1].InitialLayout[13, 14] = new Wall(false);
            Levels[1].InitialLayout[15, 14] = new Wall(false);
            Levels[1].InitialLayout[16, 14] = new Wall(false);

            Levels[1].InitialLayout[2, 13] = new Wall(false);
            Levels[1].InitialLayout[3, 13] = new Wall(false);
            Levels[1].InitialLayout[4, 13] = new Wall(false);
            Levels[1].InitialLayout[5, 13] = new Wall(false);

            Levels[1].InitialLayout[5, 12] = new Wall(false);
            Levels[1].InitialLayout[7, 12] = new Wall(false);
            Levels[1].InitialLayout[8, 12] = new Wall(false);
            Levels[1].InitialLayout[10, 12] = new Wall(false);
            Levels[1].InitialLayout[11, 12] = new Wall(false);
            Levels[1].InitialLayout[12, 12] = new Wall(false);
            Levels[1].InitialLayout[13, 12] = new Wall(false);
            Levels[1].InitialLayout[14, 12] = new Wall(false);
            Levels[1].InitialLayout[15, 12] = new Wall(false);

            Levels[1].InitialLayout[2, 11] = new Wall(false);
            Levels[1].InitialLayout[3, 11] = new Wall(false);
            Levels[1].InitialLayout[4, 11] = new Wall(false);
            Levels[1].InitialLayout[5, 11] = new Wall(false);
            Levels[1].InitialLayout[7, 11] = new Wall(false);
            Levels[1].InitialLayout[8, 11] = new Wall(false);
            Levels[1].InitialLayout[10, 11] = new Wall(false);
            Levels[1].InitialLayout[15, 11] = new Wall(false);

            Levels[1].InitialLayout[2, 10] = new Wall(false);
            Levels[1].InitialLayout[7, 10] = new Wall(false);
            Levels[1].InitialLayout[10, 10] = new Wall(false);
            Levels[1].InitialLayout[12, 10] = new Wall(false);
            Levels[1].InitialLayout[13, 10] = new Wall(false);
            Levels[1].InitialLayout[15, 10] = new Wall(false);

            Levels[1].InitialLayout[2, 9] = new Wall(false);
            Levels[1].InitialLayout[5, 9] = new Wall(false);
            Levels[1].InitialLayout[7, 9] = new Wall(false);
            Levels[1].InitialLayout[8, 9] = new Wall(false);
            Levels[1].InitialLayout[10, 9] = new Wall(false);
            Levels[1].InitialLayout[13, 9] = new Wall(false);
            Levels[1].InitialLayout[14, 9] = new Wall(false);
            Levels[1].InitialLayout[15, 9] = new Wall(false);

            Levels[1].InitialLayout[2, 8] = new Wall(false);
            Levels[1].InitialLayout[5, 8] = new Wall(false);
            Levels[1].InitialLayout[7, 8] = new Wall(false);
            Levels[1].InitialLayout[8, 8] = new Wall(false);
            Levels[1].InitialLayout[10, 8] = new Wall(false);
            Levels[1].InitialLayout[11, 8] = new Wall(false);
            Levels[1].InitialLayout[13, 8] = new Wall(false);

            Levels[1].InitialLayout[2, 7] = new Wall(false);
            Levels[1].InitialLayout[5, 7] = new Wall(false);
            Levels[1].InitialLayout[6, 7] = new Wall(false);
            Levels[1].InitialLayout[7, 7] = new Wall(false);
            Levels[1].InitialLayout[8, 7] = new Wall(false);
            Levels[1].InitialLayout[11, 7] = new Wall(false);
            Levels[1].InitialLayout[13, 7] = new Wall(false);
            Levels[1].InitialLayout[14, 7] = new Wall(false);
            Levels[1].InitialLayout[15, 7] = new Wall(false);

            Levels[1].InitialLayout[2, 6] = new Wall(false);
            Levels[1].InitialLayout[7, 6] = new Wall(false);
            Levels[1].InitialLayout[8, 6] = new Wall(false);
            Levels[1].InitialLayout[10, 6] = new Wall(false);
            Levels[1].InitialLayout[11, 6] = new Wall(false);
            Levels[1].InitialLayout[13, 6] = new Wall(false);
            Levels[1].InitialLayout[15, 6] = new Wall(false);

            Levels[1].InitialLayout[2, 5] = new Wall(false);
            Levels[1].InitialLayout[3, 5] = new Wall(false);
            Levels[1].InitialLayout[4, 5] = new Wall(false);
            Levels[1].InitialLayout[5, 5] = new Wall(false);
            Levels[1].InitialLayout[7, 5] = new Wall(false);
            Levels[1].InitialLayout[10, 5] = new Wall(false);
            Levels[1].InitialLayout[13, 5] = new Wall(false);

            Levels[1].InitialLayout[2, 4] = new Wall(false);
            Levels[1].InitialLayout[5, 4] = new Wall(false);
            Levels[1].InitialLayout[7, 4] = new Wall(false);
            Levels[1].InitialLayout[9, 4] = new Wall(false);
            Levels[1].InitialLayout[10, 4] = new Wall(false);
            Levels[1].InitialLayout[11, 4] = new Wall(false);
            Levels[1].InitialLayout[15, 4] = new Wall(false);

            Levels[1].InitialLayout[2, 3] = new Wall(false);
            Levels[1].InitialLayout[3, 3] = new Wall(false);
            Levels[1].InitialLayout[9, 3] = new Wall(false);
            Levels[1].InitialLayout[13, 3] = new Wall(false);
            Levels[1].InitialLayout[15, 3] = new Wall(false);

            Levels[1].InitialLayout[5, 2] = new Wall(false);
            Levels[1].InitialLayout[7, 2] = new Wall(false);
            Levels[1].InitialLayout[9, 2] = new Wall(false);
            Levels[1].InitialLayout[11, 2] = new Wall(false);
            Levels[1].InitialLayout[13, 2] = new Wall(false);
            Levels[1].InitialLayout[15, 2] = new Wall(false);

            Levels[1].InitialLayout[2, 1] = new Wall(false);
            Levels[1].InitialLayout[3, 1] = new Wall(false);
            Levels[1].InitialLayout[5, 1] = new Wall(false);
            Levels[1].InitialLayout[11, 1] = new Wall(false);
            Levels[1].InitialLayout[15, 1] = new Wall(false);
            ////Hardcoded water
            Levels[1].InitialLayout[3, 6] = new Water();
            Levels[1].InitialLayout[3, 7] = new Water();
            Levels[1].InitialLayout[3, 8] = new Water();
            Levels[1].InitialLayout[3, 9] = new Water();
            Levels[1].InitialLayout[3, 10] = new Water();

            Levels[1].InitialLayout[8, 15] = new Water();
            Levels[1].InitialLayout[10, 15] = new Water();
            Levels[1].InitialLayout[8, 16] = new Water();
            //Hardcoded doors
            Levels[1].InitialLayout[16, 3] = new BlueDoor();
            Levels[1].InitialLayout[1, 7] = new PurpleDoor();
            Levels[1].InitialLayout[1, 16] = new YellowDoor(CurrentLevel.LevelThree, false);
            Levels[1].InitialLayout[14, 8] = new YellowDoor(CurrentLevel.LevelOne, true);
            ////Hardcded keys
            Levels[1].InitialLayout[16, 2] = new PurpleKey();
            Levels[1].InitialLayout[10, 16] = new BlueKey();
            Levels[1].InitialLayout[14, 10] = new SkeletonKey();
            Levels[1].InitialLayout[16, 7] = new YellowKey();
        }
        public void SetLevelThreeLayout()
        {
            Levels[2].InitialLayout[1, 1] = new YellowDoor(CurrentLevel.LevelTwo, true);
            Levels[2].InitialLayout[11, 19] = new ExitDoor();
            Levels[2].InitialLayout[11, 20] = new Wall(false);
            Levels[2].InitialLayout[11, 18] = new Wall(false);
        }
    }
}
            
