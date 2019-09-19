namespace DungeonCrawler
{
    public class LevelLayout
    {
        public Level[] Levels = new Level[3];
        
        Level level1 = new Level(new Size(16, 16), new Point(1,1));
        Level level2 = new Level(new Size(18, 18), new Point(17, 17));
        Level level3 = new Level(new Size(24, 14), new Point(1, 1));

        public LevelLayout()
        {
            Levels[0] = level1;
            Levels[1] = level2;
            Levels[2] = level3;
        }

    } 

}
