﻿using System;
using System.Collections.Generic;
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
        private Point[] pointsToRenderOnMap;
        private Point[] previousEnemyPositions;
        private Point[] keyPositions;
        private Point[] doorPositions;
        private Point[] wallPositions;
        private Point[] floorPositions;
        private CurrentLevel levelIndex;
        private State currentState;

        public Point PlayerPosition { get { return currentPlayerPosition; } set { currentPlayerPosition = value; } }
        public Point TargetPlayerPosition { get { return targetPlayerPosition; } set { targetPlayerPosition = value; } }
        public int PlayerNumberOfMoves { get { return playerNumberOfMoves; } set { playerNumberOfMoves = value; } }
        public Point CurrentEnemyPosition { get { return currentEnemyPosition; } set { currentEnemyPosition = value; } }
        public Point TargetEnemyPosition { get { return targetEnemyPosition; } set { targetEnemyPosition = value; } }
        public Point[] PreviousEnemyPositions { get { return previousEnemyPositions; } set { previousEnemyPositions = value; } }
        public Point[] KeyPositions { get { return keyPositions; } set { keyPositions = value; } }
        public Point[] DoorPositions { get { return doorPositions; } set { doorPositions = value; } }
        public Point[] WallPositions { get { return wallPositions; } set { wallPositions = value; } }
        public Point[] FloorPositions { get { return floorPositions; } set { floorPositions = value; } }
        public State CurrentState { get { return currentState; } set { currentState = value; } }
        public CurrentLevel LevelIndex { get { return levelIndex; } set { levelIndex = value; } }
        public Point[] PointsToRenderOnMap { get { return pointsToRenderOnMap; } set { pointsToRenderOnMap = value; } }
    }
}
