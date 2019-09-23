

using System;
using System.Media;

namespace DungeonCrawler
{
    public abstract class Key : Tile, IInteractable
    {
        private SoundPlayer SoundPlayer = new SoundPlayer();
        private bool isEquipped;
        private Unlock unlock;
        private byte numberOfUses;
        private Point position;

        public bool IsEquipped
        {
            get { return isEquipped; }
            set { isEquipped = value; }
        }
        public Unlock Unlock
        {
            get { return unlock; }
            set { unlock = value; }
        }
        public byte NumberOfUses
        {
            get { return numberOfUses; }
            set { numberOfUses = value; }
        }
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }
        public bool Interact()
        {
            Player.KeysInInventory.Add(this);
            SoundPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\pickup-key.wav";
            SoundPlayer.LoadAsync();
            SoundPlayer.Play();
            return true;
        }
    }
}
