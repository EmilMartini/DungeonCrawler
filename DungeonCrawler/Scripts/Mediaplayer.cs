using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public static class Mediaplayer
    {
        private static SoundPlayer SoundPlayer = new SoundPlayer();
        public static void PlayDoorEffect()
        {
            SoundPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\open-close-door.wav";
            SoundPlayer.Play();
        }

        internal static void PlayMainTheme()
        {
            SoundPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\main-theme-atmosphere.wav";
            SoundPlayer.PlayLooping();
        }
    }
}
