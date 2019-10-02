using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//amespace DungeonCrawler.Scripts
//
//   class DataHolder
//   {
//       private Point currentPlayerPosition;
//       private Point targetPlayerPosition;
//       private int playerNumberOfMoves;
//       private Point currentEnemyPosition;
//       private Point targetEnemyPosition;
//       private Level[] levels;
//       private Point[] pointsToRenderOnMap;
//       private Point[] previousEnemyPositions;
//       private CurrentLevel currentLevel;
//       private CurrentLevel nextLevel;
//       private State currentState;
//       private int consoleWindowWidth;
//       private int consoleWindowHeight;
//
//       public DataHolder(StateMachine.State currentState, DataInitializer dataInitializer)
//       {
//           switch (currentState)
//           {
//               case StateMachine.State.InitializeGame:
//                   this.Levels = dataInitializer.LevelLayout.Levels;
//                   this.ConsoleWindowWidth = Console.WindowWidth;
//                   this.ConsoleWindowHeight = Console.WindowHeight;
//                   break;
//               case StateMachine.State.InitializeLevel:
//                   break;
//               case StateMachine.State.WelcomeScreen:
//                   break;
//               case StateMachine.State.RunLevel:
//                   this.currentPlayerPosition = dataInitializer.Player.Position;
//                   this.targetPlayerPosition = dataInitializer.Player.TargetPosition;
//                   this.CurrentEnemyPosition = dataInitializer.EnemyController.CurrentEnemyPosition;
//                   this.TargetEnemyPosition = dataInitializer.EnemyController.TargetEnemyPosition;
//                   break;
//               case StateMachine.State.ExitLevel:
//                   break;
//               case StateMachine.State.ExitGame:
//                   break;
//               default:
//                   break;
//           }
//       }
//
//       public Point PlayerPosition { get { return currentPlayerPosition; } set { currentPlayerPosition = value; } }
//       public Point TargetPlayerPosition { get { return targetPlayerPosition; } set { targetPlayerPosition = value; } }
//       public int PlayerNumberOfMoves { get { return playerNumberOfMoves; } set { playerNumberOfMoves = value; } }
//       public Point CurrentEnemyPosition { get { return currentEnemyPosition; } set { currentEnemyPosition = value; } }
//       public Point TargetEnemyPosition { get { return targetEnemyPosition; } set { targetEnemyPosition = value; } }
//       public Point[] PreviousEnemyPositions { get { return previousEnemyPositions; } set { previousEnemyPositions = value; } }
//       public CurrentLevel CurrentLevel { get { return currentLevel; } set { currentLevel = value; } }
//       public Point[] PointsToRenderOnMap { get { return pointsToRenderOnMap; } set { pointsToRenderOnMap = value; } }
//       public Level[] Levels { get { return levels; } set { levels = value; } }
//       public CurrentLevel NextLevel { get { return nextLevel; } set { nextLevel = value; } }
//       public StateMachine.State CurrentState { get => currentState; set => currentState = value; }
//       public int ConsoleWindowWidth { get { return consoleWindowWidth; } set { consoleWindowWidth = value; } }
//       public int ConsoleWindowHeight { get { return consoleWindowHeight; } set { consoleWindowHeight = value; } }
//   }
//
