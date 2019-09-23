namespace DungeonCrawler
{
    public class Level
    {
        private Tile[,] exploredLayout;
        private Tile[,] initialLayout;
        private Enemy[] enemies;
        private Point[] previousEnemyPositions;
        private Door[] doorsOnMap;
        private Key[] keysOnMap;
        private Size size;
        private Point playerStartingTile;
        private int numberOfEnemies;
        private int numberOfKeys;
        private int numberOfDoors;

        public Level(Size size, Point playerStartingTile, int numberOfEnemies, int numberOfKeys, int numberOfDoors)
        {
            Size = size;
            PlayerStartingTile = playerStartingTile;
            NumberOfEnemies = numberOfEnemies;
            NumberOfDoors = numberOfDoors;
            NumberOfKeys = numberOfKeys;
        }

        public Tile[,] ExploredLayout
        {
            get { return exploredLayout; }
            set { exploredLayout = value; }
        }
        public Tile[,] InitialLayout
        {
            get { return initialLayout; }
            set { initialLayout = value; }
        }
        public Enemy[] Enemies
        {
            get { return enemies; }
            set { enemies = value; }
        }
        public Point[] PreviousEnemyPositions
        {
            get { return previousEnemyPositions; }
            set { previousEnemyPositions = value; }
        }
        public Door[] DoorsOnMap
        {
            get { return doorsOnMap; }
            set { doorsOnMap = value; }
        }
        public Key[] KeysOnMap
        {
            get { return keysOnMap; }
            set { keysOnMap = value; }
        }
        public Size Size
        {
            get { return size; }
            set { size = value; }
        }
        public Point PlayerStartingTile
        {
            get { return playerStartingTile; }
            set { playerStartingTile = value; }
        }
        public int NumberOfEnemies
        {
            get { return numberOfEnemies; }
            set { numberOfEnemies = value; }
        }
        public int NumberOfKeys
        {
            get { return numberOfKeys; }
            set { numberOfKeys = value; }
        }
        public int NumberOfDoors
        {
            get { return numberOfDoors; }
            set { numberOfDoors = value; }
        }
    }
}
