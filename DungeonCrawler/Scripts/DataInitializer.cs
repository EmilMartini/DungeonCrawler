using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class DataInitializer
    {
        private LevelLayout levelLayout;
        private Player player;
        private LevelRenderer levelRenderer;
        private LevelLoader levelLoader;
        private EnemyController enemyController;
        private PlayerController playerController;
        private ConsoleOutputFilter consoleOutputFilter;

        public DataInitializer(StateMachine stateMachine)
        {
            LevelLayout = new LevelLayout(stateMachine);
            Player = new Player();
            LevelRenderer = new LevelRenderer(stateMachine.Levels, player, stateMachine);
            LevelLoader = new LevelLoader(LevelLayout, stateMachine);
            EnemyController = new EnemyController(stateMachine);
            PlayerController = new PlayerController(Player, stateMachine);
            ConsoleOutputFilter = new ConsoleOutputFilter();
        }

        public LevelLayout LevelLayout { get {return levelLayout ;} set { levelLayout = value;} }
        public Player Player { get => player; set => player = value; }
        public LevelRenderer LevelRenderer { get => levelRenderer; set => levelRenderer = value; }
        public LevelLoader LevelLoader { get => levelLoader; set => levelLoader = value; }
        public EnemyController EnemyController { get => enemyController; set => enemyController = value; }
        public PlayerController PlayerController { get => playerController; set => playerController = value; }
        public ConsoleOutputFilter ConsoleOutputFilter { get => consoleOutputFilter; set => consoleOutputFilter = value; }
    }
}
