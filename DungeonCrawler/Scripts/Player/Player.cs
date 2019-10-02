using System;
using System.Collections.Generic;
namespace DungeonCrawler
{
    public class Player : GameObject
    {   //Add playerposition
        private PlayerInventory playerInventory;
        private int enemiesInteractedWith = 0;
        private int numberOfMoves;
        public Player()
        {
            this.PlayerInventory = new PlayerInventory(this);   //Kanske ska ta playerInventory som parameter? Men då måste vi ha playerInventory som referens i gameplayManager
            this.Graphic = "@";
            this.Color = ConsoleColor.Green;
            this.Position = new Point(1,1);
        }
        public int EnemiesInteractedWith
        {
            get { return enemiesInteractedWith; }
            set { enemiesInteractedWith = value; }
        }
        public Point TargetPosition { get; set; }
        public int NumberOfMoves { get => numberOfMoves; set => numberOfMoves = value; }    //Fixa samma enkapsulering som andra properties
        internal PlayerInventory PlayerInventory { get => playerInventory; set => playerInventory = value; } //Fixa samma enkapsulering som andra properties
    }
}
