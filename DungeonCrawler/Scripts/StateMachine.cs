using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class StateMachine
    {
        public enum State { InitializeGame, InitializeLevel, WelcomeScreen, RunLevel, ExitLevel, ExitGame }
        private Point currentPlayerPosition;
        private Point targetPlayerPosition;
        private int playerNumberOfMoves;
        private Point currentEnemyPosition;
        private Point targetEnemyPosition;
        private Level[] levels;
        private Point[] pointsToRenderOnMap;
        private CurrentLevel currentLevel;
        private CurrentLevel nextLevel;
        private State currentState;
        private DataInitializer dataInitializer;
        private System.IO.TextWriter standardOutputWriter;

        //  void GetData(State);
        //      should get different data depending on state. void or return Data class? Maybe redo dataInitializer class?
        //
        //  method to return a state. State GetState(Data onject?);
        //      main should only run one method, void RunState(state) with a returned state from statemachine as param
        //
        //  Remove most references in statemachine class and create a dataholder class. Dataholder class will
        //  instantiate a new object when GetData is called and that object is then passed into GetState and GetState will return a state depending on dataparam
        //  Dataholder doesnt handle logic, only data. Will fetch data from some major statedetermening methods and/or variables
        //  e.g playerposition, levels etc.
        //
        //  Not 100% sure, but will probably work.
        
        
        public Point PlayerPosition { get { return currentPlayerPosition; } set { currentPlayerPosition = value; } }
        public Point TargetPlayerPosition { get { return targetPlayerPosition; } set { targetPlayerPosition = value; } }
        public int PlayerNumberOfMoves { get { return playerNumberOfMoves; } set { playerNumberOfMoves = value; } }
        public Point CurrentEnemyPosition { get { return currentEnemyPosition; } set { currentEnemyPosition = value; } }
        public Point TargetEnemyPosition { get { return targetEnemyPosition; } set { targetEnemyPosition = value; } }
        public State CurrentState { get { return currentState; } set { currentState = value; } }
        public CurrentLevel CurrentLevel { get { return currentLevel; } set { currentLevel = value; } }
        public Point[] PointsToRenderOnMap { get { return pointsToRenderOnMap; } set { pointsToRenderOnMap = value; } }
        public Level[] Levels { get { return levels; } set { levels = value; } }
        public DataInitializer DataInitializer { get { return dataInitializer; } set { dataInitializer = value; } }
        public TextWriter StandardOutputWriter { get { return standardOutputWriter; } set { standardOutputWriter = value; } }
        public CurrentLevel NextLevel { get { return nextLevel; } set { nextLevel = value; } }
    }
}
