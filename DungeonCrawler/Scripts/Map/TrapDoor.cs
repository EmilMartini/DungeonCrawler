using System;

namespace DungeonCrawler
{
    public class TrapDoor : Tile, IInteractable
    {
        private StateMachine stateMachine;
        public TrapDoor(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            this.TileType = TileType.TrapDoor;
            this.IsExplored = false;
            this.Color = ConsoleColor.DarkGray;
            this.Graphic = ".";
        }

        public bool Interact()
        {
            stateMachine.CurrentState = StateMachine.State.ExitLevel;
            return true;
        }
    }
}