using System;
namespace DungeonCrawler
{
    public class LevelRenderer
    {
        private readonly Level level;
        private readonly Player player;
        private readonly Size consoleWindowSize = new Size(72, 36);

        public Point[] pointsToRender = new Point[8];

        public LevelRenderer(Level level, Player player)
        {
            this.level = level ?? throw new ArgumentNullException(nameof(level));
            this.player = player ?? throw new ArgumentNullException(nameof(player));
        }

        public void RenderLevel()
        {
            Point distanceBetweenTiles = new Point(((int)consoleWindowSize.Width / level.ExploredLayout.GetLength(0)), ((int)consoleWindowSize.Height / level.ExploredLayout.GetLength(1)));
            GetTilesToExplore(player.Position);
            SetTilesToExplored(pointsToRender);

            for (int i = 0; i < pointsToRender.Length; i++)
            {
                Console.ForegroundColor = level.ExploredLayout[pointsToRender[i].row, pointsToRender[i].column].Color;
                Console.SetCursorPosition(distanceBetweenTiles.row * pointsToRender[i].column, distanceBetweenTiles.column * pointsToRender[i].row);
                Console.Write($"{level.ExploredLayout[pointsToRender[i].row,pointsToRender[i].column].Graphic}");

                Console.ForegroundColor = level.ExploredLayout[player.Position.row, player.Position.column].Color;
                Console.SetCursorPosition(distanceBetweenTiles.row * player.Position.column, distanceBetweenTiles.column * player.Position.row);
                Console.Write($"{player.Graphic}");
            }
        }

        private void SetTilesToExplored(Point[] pointsToRender)
        {
            for (int i = 0; i < pointsToRender.Length; i++)
            {
                level.ExploredLayout[pointsToRender[i].row, pointsToRender[i].column].IsExplored = true;
            }
        }

        public void GetTilesToExplore(Point playerPosition)
        {   
            pointsToRender[0] = new Point(playerPosition.row, playerPosition.column - 1);
            pointsToRender[1] = new Point(playerPosition.row, playerPosition.column + 1);

            pointsToRender[2] = new Point(playerPosition.row - 1, playerPosition.column);
            pointsToRender[3] = new Point(playerPosition.row + 1, playerPosition.column);

            pointsToRender[4] = new Point(playerPosition.row + 1, playerPosition.column + 1);
            pointsToRender[5] = new Point(playerPosition.row - 1, playerPosition.column + 1);

            pointsToRender[6] = new Point(playerPosition.row - 1, playerPosition.column - 1);
            pointsToRender[7] = new Point(playerPosition.row + 1, playerPosition.column - 1);
        }

        public void UpdatePlayerPosition(Point targetPosition)
        {
            level.ExploredLayout[player.Position.row, player.Position.column] = level.InitialLayout[player.Position.row, player.Position.column];
            player.Position = targetPosition;
            level.ExploredLayout[player.Position.row, player.Position.column] = player;
        }

        public void UpdateMonsterPosition(Enemy enemy, Point targetPosition)
        {
            level.ExploredLayout[enemy.Position.row, enemy.Position.column] = level.InitialLayout[enemy.Position.row, enemy.Position.column];
            enemy.Position = targetPosition;
            level.ExploredLayout[enemy.Position.row, enemy.Position.column] = enemy;
        }
    }
}
