using DungeonCrawler.Doors;
using DungeonCrawler.Keys;
namespace DungeonCrawler
{
    public class LevelLayout
    {
        private Level[] levels = new Level[3];
        private Point[] spawnPoints = new Point[3];
        private readonly static Point level1SpawnPoint = new Point(1, 1);
        private readonly static Point level2SpawnPoint = new Point(14, 8);
        private readonly static Point level3SpawnPoint = new Point(1, 1);
        readonly Level level1 = new Level(new Size(25, 25), level1SpawnPoint, 8);
        readonly Level level2 = new Level(new Size(18, 18), level2SpawnPoint, 0);
        readonly Level level3 = new Level(new Size(23, 13), level3SpawnPoint, 10);
        private readonly GameplayManager gameplayManager;
        public LevelLayout(GameplayManager gameplayManager)
        {
            Levels[0] = level1;
            Levels[1] = level2;
            Levels[2] = level3;

            spawnPoints[0] = level1SpawnPoint;
            spawnPoints[1] = level2SpawnPoint;
            spawnPoints[2] = level3SpawnPoint;
            this.gameplayManager = gameplayManager;
            gameplayManager.Levels = Levels;
        }
        public void SetLevelOneLayout()
        {
            
            //Hardcoded walls
            Levels[0].Layout[14, 1] = new Wall(false);
            Levels[0].Layout[14, 2] = new Wall(false);
            Levels[0].Layout[14, 3] = new Wall(false);
            Levels[0].Layout[14, 4] = new Wall(false);
            Levels[0].Layout[14, 5] = new Wall(false);
            Levels[0].Layout[14, 6] = new Wall(false);
            Levels[0].Layout[14, 8] = new Wall(false);
            Levels[0].Layout[14, 9] = new Wall(false);
            Levels[0].Layout[15, 9] = new Wall(false);
            Levels[0].Layout[16, 9] = new Wall(false);
            Levels[0].Layout[17, 9] = new Wall(false);
            Levels[0].Layout[18, 9] = new Wall(false);
            Levels[0].Layout[19, 9] = new Wall(false);
            Levels[0].Layout[20, 9] = new Wall(false);
            Levels[0].Layout[21, 9] = new Wall(false);
            Levels[0].Layout[22, 9] = new Wall(false);
            Levels[0].Layout[23, 9] = new Wall(false);

            Levels[0].Layout[1, 15] = new Wall(false);
            Levels[0].Layout[2, 15] = new Wall(false);
            Levels[0].Layout[3, 15] = new Wall(false);
            Levels[0].Layout[4, 15] = new Wall(false);
            Levels[0].Layout[5, 15] = new Wall(false);
            Levels[0].Layout[6, 15] = new Wall(false);
            Levels[0].Layout[7, 15] = new Wall(false);
            Levels[0].Layout[8, 15] = new Wall(false);
            Levels[0].Layout[9, 15] = new Wall(false);
            Levels[0].Layout[9, 16] = new Wall(false);
            Levels[0].Layout[9, 17] = new Wall(false);
            Levels[0].Layout[9, 18] = new Wall(false);
            Levels[0].Layout[9, 19] = new Wall(false);
            Levels[0].Layout[9, 21] = new Wall(false);
            Levels[0].Layout[9, 22] = new Wall(false);
            Levels[0].Layout[9, 23] = new Wall(false);
            Levels[0].Layout[23, 3] = new Wall(false);
            Levels[0].Layout[23, 5] = new Wall(false);
            //Hardcoded doors
            Levels[0].Layout[1, 1] = new ExitDoor(false);
            Levels[0].Layout[14, 7] = new BlueDoor();
            Levels[0].Layout[9, 20] = new PurpleDoor();
            Levels[0].Layout[23, 4] = new YellowDoor(CurrentLevel.LevelTwo, false, gameplayManager);
            Levels[0].Layout[23,23] = new PressurePlate(23, 23);
            //Hardcoded keys
            Levels[0].ActiveGameObjects.Add(new PurpleKey(6,2));
            Levels[0].ActiveGameObjects.Add(new BlueKey(2,18));
            Levels[0].ActiveGameObjects.Add(new YellowKey(22,22));
            Levels[0].ActiveGameObjects.Add(new Potion(4, 6));           
        }
        public void SetLevelTwoLayout()
        {
            //Hardcoded walls
            Levels[1].Layout[5, 16] = new Wall(false);
            Levels[1].Layout[7, 16] = new Wall(false);
            Levels[1].Layout[11, 16] = new Wall(false);
            Levels[1].Layout[15, 16] = new Wall(false);
            Levels[1].Layout[16, 16] = new Wall(false);

            Levels[1].Layout[1, 15] = new Wall(false);
            Levels[1].Layout[2, 15] = new Wall(false);
            Levels[1].Layout[3, 15] = new Wall(false);
            Levels[1].Layout[5, 15] = new Wall(false);
            Levels[1].Layout[7, 15] = new Wall(false);
            Levels[1].Layout[11, 15] = new Wall(false);
            Levels[1].Layout[13, 15] = new Wall(false);

            Levels[1].Layout[5, 14] = new Wall(false);
            Levels[1].Layout[7, 14] = new Wall(false);
            Levels[1].Layout[8, 14] = new Wall(false);
            Levels[1].Layout[10, 14] = new Wall(false);
            Levels[1].Layout[11, 14] = new Wall(false);
            Levels[1].Layout[12, 14] = new Wall(false);
            Levels[1].Layout[13, 14] = new Wall(false);
            Levels[1].Layout[15, 14] = new Wall(false);
            Levels[1].Layout[16, 14] = new Wall(false);

            Levels[1].Layout[2, 13] = new Wall(false);
            Levels[1].Layout[3, 13] = new Wall(false);
            Levels[1].Layout[4, 13] = new Wall(false);
            Levels[1].Layout[5, 13] = new Wall(false);

            Levels[1].Layout[5, 12] = new Wall(false);
            Levels[1].Layout[7, 12] = new Wall(false);
            Levels[1].Layout[8, 12] = new Wall(false);
            Levels[1].Layout[10, 12] = new Wall(false);
            Levels[1].Layout[11, 12] = new Wall(false);
            Levels[1].Layout[12, 12] = new Wall(false);
            Levels[1].Layout[13, 12] = new Wall(false);
            Levels[1].Layout[14, 12] = new Wall(false);
            Levels[1].Layout[15, 12] = new Wall(false);

            Levels[1].Layout[2, 11] = new Wall(false);
            Levels[1].Layout[3, 11] = new Wall(false);
            Levels[1].Layout[4, 11] = new Wall(false);
            Levels[1].Layout[5, 11] = new Wall(false);
            Levels[1].Layout[7, 11] = new Wall(false);
            Levels[1].Layout[8, 11] = new Wall(false);
            Levels[1].Layout[10, 11] = new Wall(false);
            Levels[1].Layout[15, 11] = new Wall(false);

            Levels[1].Layout[2, 10] = new Wall(false);
            Levels[1].Layout[7, 10] = new Wall(false);
            Levels[1].Layout[10, 10] = new Wall(false);
            Levels[1].Layout[12, 10] = new Wall(false);
            Levels[1].Layout[13, 10] = new Wall(false);
            Levels[1].Layout[15, 10] = new Wall(false);

            Levels[1].Layout[2, 9] = new Wall(false);
            Levels[1].Layout[5, 9] = new Wall(false);
            Levels[1].Layout[7, 9] = new Wall(false);
            Levels[1].Layout[8, 9] = new Wall(false);
            Levels[1].Layout[10, 9] = new Wall(false);
            Levels[1].Layout[13, 9] = new Wall(false);
            Levels[1].Layout[14, 9] = new Wall(false);
            Levels[1].Layout[15, 9] = new Wall(false);

            Levels[1].Layout[2, 8] = new Wall(false);
            Levels[1].Layout[5, 8] = new Wall(false);
            Levels[1].Layout[7, 8] = new Wall(false);
            Levels[1].Layout[8, 8] = new Wall(false);
            Levels[1].Layout[10, 8] = new Wall(false);
            Levels[1].Layout[11, 8] = new Wall(false);
            Levels[1].Layout[13, 8] = new Wall(false);

            Levels[1].Layout[2, 7] = new Wall(false);
            Levels[1].Layout[5, 7] = new Wall(false);
            Levels[1].Layout[6, 7] = new Wall(false);
            Levels[1].Layout[7, 7] = new Wall(false);
            Levels[1].Layout[8, 7] = new Wall(false);
            Levels[1].Layout[11, 7] = new Wall(false);
            Levels[1].Layout[13, 7] = new Wall(false);
            Levels[1].Layout[14, 7] = new Wall(false);
            Levels[1].Layout[15, 7] = new Wall(false);

            Levels[1].Layout[2, 6] = new Wall(false);
            Levels[1].Layout[7, 6] = new Wall(false);
            Levels[1].Layout[8, 6] = new Wall(false);
            Levels[1].Layout[10, 6] = new Wall(false);
            Levels[1].Layout[11, 6] = new Wall(false);
            Levels[1].Layout[13, 6] = new Wall(false);
            Levels[1].Layout[15, 6] = new Wall(false);

            Levels[1].Layout[2, 5] = new Wall(false);
            Levels[1].Layout[3, 5] = new Wall(false);
            Levels[1].Layout[4, 5] = new Wall(false);
            Levels[1].Layout[5, 5] = new Wall(false);
            Levels[1].Layout[7, 5] = new Wall(false);
            Levels[1].Layout[10, 5] = new Wall(false);
            Levels[1].Layout[13, 5] = new Wall(false);

            Levels[1].Layout[2, 4] = new Wall(false);
            Levels[1].Layout[5, 4] = new Wall(false);
            Levels[1].Layout[7, 4] = new Wall(false);
            Levels[1].Layout[9, 4] = new Wall(false);
            Levels[1].Layout[10, 4] = new Wall(false);
            Levels[1].Layout[11, 4] = new Wall(false);
            Levels[1].Layout[15, 4] = new Wall(false);

            Levels[1].Layout[2, 3] = new Wall(false);
            Levels[1].Layout[3, 3] = new Wall(false);
            Levels[1].Layout[9, 3] = new Wall(false);
            Levels[1].Layout[13, 3] = new Wall(false);
            Levels[1].Layout[15, 3] = new Wall(false);

            Levels[1].Layout[5, 2] = new Wall(false);
            Levels[1].Layout[7, 2] = new Wall(false);
            Levels[1].Layout[9, 2] = new Wall(false);
            Levels[1].Layout[11, 2] = new Wall(false);
            Levels[1].Layout[13, 2] = new Wall(false);
            Levels[1].Layout[15, 2] = new Wall(false);

            Levels[1].Layout[2, 1] = new Wall(false);
            Levels[1].Layout[3, 1] = new Wall(false);
            Levels[1].Layout[5, 1] = new Wall(false);
            Levels[1].Layout[11, 1] = new Wall(false);
            Levels[1].Layout[15, 1] = new Wall(false);
            
            //Hardcoded doors
            Levels[1].Layout[16, 3] = new BlueDoor();
            Levels[1].Layout[1, 7] = new PurpleDoor();
            Levels[1].Layout[1, 16] = new YellowDoor(CurrentLevel.LevelThree, false, gameplayManager);
            Levels[1].Layout[14, 8] = new YellowDoor(CurrentLevel.LevelOne, true, gameplayManager);
            ////Hardcded keys
            Levels[1].ActiveGameObjects.Add(new PurpleKey(16,2));
            Levels[1].ActiveGameObjects.Add(new BlueKey(10,16));
            Levels[1].ActiveGameObjects.Add(new SkeletonKey(14,10));
            Levels[1].ActiveGameObjects.Add(new YellowKey(12,15));
        }
        public void SetLevelThreeLayout()
        {
            Levels[2].Layout[1, 1] = new YellowDoor(CurrentLevel.LevelTwo, true, gameplayManager);
            Levels[2].Layout[11, 19] = new ExitDoor(false);
            Levels[2].Layout[11, 20] = new Wall(false);
            Levels[2].Layout[11, 18] = new Wall(false);
        }
        public Level[] Levels { get => levels; set => levels = value; }
    }
}
            
