using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class StateMachine
    {
        public enum State { InitializeGame, InitializeLevel, WelcomeScreen, RunLevel, ExitLevel, ExitGame }
        private Point playerPosition;
        private Point[] enemyPositions;
        private Point[] keyPositions;
        private Point[] doorPositions;
        private Point[] wallPositions;
        private Point[] floorPositions;
        private CurrentLevel levelIndex;
        private State currentState;

        public Point PlayerPosition { get { return playerPosition; } set { playerPosition = value; } }
        public Point[] EnemyPositions { get { return enemyPositions; } set { enemyPositions = value; } }
        public Point[] KeyPositions { get { return keyPositions; } set { keyPositions = value; } }
        public Point[] DoorPositions { get { return doorPositions; } set { doorPositions = value; } }
        public Point[] WallPositions { get { return wallPositions; } set { wallPositions = value; } }
        public Point[] FloorPositions { get { return floorPositions; } set { floorPositions = value; } }
        public State CurrentState { get { return currentState; } set { currentState = value; } }
        public CurrentLevel LevelIndex { get { return levelIndex; } set { levelIndex = value; } }
    }
}
