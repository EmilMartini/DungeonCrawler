﻿using System;
using System.Collections.Generic;

namespace DungeonCrawler
{
    class LevelCreator
    {
        private static Random random = new Random();

        private static readonly char[,] LevelOne = {{ '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                                                    { '#', 'G', '-', '-', '-', '-', '-', '-', '-', '-', '-', 'b', '-', '#', 'p', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '.', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '#', '#', '#', '#', 'B', '#', '#', '#', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '#', '#', '#', '#', '#', 'P', '#', '#', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '#', '#', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '#', 'y', '#' },
                                                    { '#', 'c', '-', '#', '2', '#', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' } };

        private static readonly char[,] LevelTwo = {{ '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', 'P', '-', '-', '-', '-', '-', '-', '-', '#', '2', '#' },
                                                    { '#', '#', '-', '#', '#', '#', '#', '#', '#', '#', '#', '#', '-', '#', '-', '#', '-', '#' },
                                                    { '#', '#', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '#', '-', '#' },
                                                    { '#', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '#', '-', '#', '-', '-', '-', '#' },
                                                    { '#', '#', '#', '-', '#', '#', '-', '#', '#', '#', '-', '#', '#', '#', '#', '#', '#', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '-', '#', '-', '#', '#', '#', '#', '#', '#', '#', '#', '#', '-', '#', '#', '#', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '#', '#', '#', '#', '-', '#', '#', '-', '#', '-', '-', '#' },
                                                    { '#', '-', '#', '#', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                    { '#', '-', '-', '-', '#', '#', '#', '-', '#', '#', '#', '#', '#', '-', '#', '-', 'b', '#' },
                                                    { '#', '#', '#', '-', '#', '-', '#', '#', '#', '-', '-', '-', '#', '-', '#', '#', '#', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '#', '-', '#', 'y', '-', '#' },
                                                    { '#', '-', '#', '#', '-', '#', '#', '#', '#', '#', '#', '-', '#', '-', '#', '#', '-', '#' },
                                                    { '#', '-', '-', '-', '-', '-', '-', '#', '1', '#', 'g', '-', '#', '-', '-', '-', '-', '#' },
                                                    { '#', '#', '#', '#', '#', '-', '#', '#', '-', '#', '#', '#', '#', '-', '#', '-', '#', '#' },
                                                    { '#', 'p', '-', 'B', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '#', '#' },
                                                    { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' } };

        private static readonly char[,] LevelThree = {{ '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                                                        { '#', '1', '-', '-', '-', '-', '-', '-', '-', '-', '-', 'b', '-', '#', 'p', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                        { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                        { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                        { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                        { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                        { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                        { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                        { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                        { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                        { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '#', '#', '#', '#', 'B', '#', '#', '#', '#' },
                                                        { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                        { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                        { '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                        { '#', '#', '#', '#', '#', '#', 'P', '#', '#', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                        { '#', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                        { '#', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                        { '#', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                        { '#', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                        { '#', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '#', '#', '#' },
                                                        { '#', '-', '-', '-', '-', '-', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#', '#', '-', '#' },
                                                        { '#', 'c', '-', '#', 'G', '#', '-', '-', '-', '#', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '#' },
                                                        { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
        };
        public static List<Level> GetLevels()
        {
            return new List<Level>
            {
                CreateLevel(LevelOne, 5),
                CreateLevel(LevelTwo, 0),
                CreateLevel(LevelThree, 10)
            };
        }
        private static Level CreateLevel(char[,] charLayout, int amountOfEnemies)
        {
            var entryDoor = new Point(0, 0);
            var exitDoor = new Point(0, 0);
            var playerStartingPosition = new Point(0, 0);
            var levelHeight = charLayout.GetLength(0);
            var levelWidth = charLayout.GetLength(1);
            var levelLayout = new Tile[levelHeight, levelWidth];
            var activeGameObjects = new List<GameObject>();

            for (var row = 0; row < levelHeight; row++)
            {
                for (var column = 0; column < levelWidth; column++)
                {
                    switch (charLayout[row, column])
                    {
                        case '#':
                            if (row == 0 || row == levelHeight - 1 || column == 0 || column == levelWidth - 1)
                                levelLayout[row, column] = new Wall(true);
                            else
                                levelLayout[row, column] = new Wall(false);
                            break;
                        case '-':
                            levelLayout[row, column] = new Floor();
                            break;
                        case 'P':
                            levelLayout[row, column] = new PurpleDoor();
                            break;
                        case 'B':
                            levelLayout[row, column] = new BlueDoor();
                            break;
                        case 'G':
                            levelLayout[row, column] = new ExitDoor(false);
                            break;
                        case '.':
                            levelLayout[row, column] = new PressurePlate(row, column);
                            break;
                        case 'y':
                            activeGameObjects.Add(new YellowKey(row, column));
                            levelLayout[row, column] = new Floor();
                            break;
                        case 'p':
                            activeGameObjects.Add(new PurpleKey(row, column));
                            levelLayout[row, column] = new Floor();
                            break;
                        case 'b':
                            activeGameObjects.Add(new BlueKey(row, column));
                            levelLayout[row, column] = new Floor();
                            break;
                        case 'g':
                            activeGameObjects.Add(new SkeletonKey(row, column));
                            levelLayout[row, column] = new Floor();
                            break;
                        case 'c':
                            activeGameObjects.Add(new Potion(row, column));
                            levelLayout[row, column] = new Floor();
                            break;
                        case '1':
                            entryDoor = new Point(row, column);
                            playerStartingPosition = new Point(row, column);
                            levelLayout[row, column] = new YellowDoor(true);
                            break;
                        case '2':
                            exitDoor = new Point(row, column);
                            levelLayout[row, column] = new YellowDoor(false);
                            break;
                        default:
                            levelLayout[row, column] = new Floor();
                            break;
                    }
                }
            }
            for (var i = 0; i < amountOfEnemies; i++)
            {
                activeGameObjects.Add(new Enemy(CreateRandomPoint(levelHeight - 2, levelWidth - 2)));
            }
            return new Level(levelLayout, activeGameObjects, playerStartingPosition, amountOfEnemies, entryDoor, exitDoor);
        }
        private static Point CreateRandomPoint(int x, int y)
        {
            return new Point(random.Next(1, x), random.Next(1, y));
        }

    }
}



