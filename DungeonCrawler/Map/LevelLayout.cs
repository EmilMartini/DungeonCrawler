namespace DungeonCrawler
{
    public class LevelLayout
    {
        public Level[] Levels = new Level[3];
        
        Level level1 = new Level(new Size(25, 25), new Point(1,1));
        Level level2 = new Level(new Size(18, 18), new Point(17, 17));
        Level level3 = new Level(new Size(24, 14), new Point(1, 1));

        public LevelLayout()
        {
            Levels[0] = level1;
            Levels[1] = level2;
            Levels[2] = level3;
        }

        public void InitializeLevels()
        {
            for (int i = 0; i < Levels.Length; i++)
            {
                Levels[i].InitialLayout = new Tile[Levels[i].Size.Height, Levels[i].Size.Width];
                Levels[i].ExploredLayout = new Tile[Levels[i].Size.Height, Levels[i].Size.Width];
                Levels[i].Enemies = new Enemy[] { new Enemy(3, 2), new Enemy(5, 2) };

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
                Array.Copy(levels[currentLevel].InitialLayout, levels[currentLevel].ExploredLayout, levels[currentLevel].InitialLayout.Length);
                levels[currentLevel].ExploredLayout[player.Position.row, player.Position.column] = player;

                for (int i = 0; i < levels[currentLevel].Enemies.Length; i++)
                {
                    levels[currentLevel].ExploredLayout[levels[currentLevel].Enemies[i].Position.row, levels[currentLevel].Enemies[i].Position.column] = levels[currentLevel].Enemies[i];
                }
            }
        }
    }
}
