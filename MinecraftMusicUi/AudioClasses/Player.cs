using MinecraftMusicUi.Model;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MinecraftMusicUi.AudioClasses
{
    public class Player
    {
        public Disc disc { get; set; }
        public WaveOut waveOut { get; set; }
        public Mp3FileReader mp3Reader { get; set; }
        public string playerButtonImagePath { get; set; }
        public string strTimer
        {
            get
            {
                return $"{mp3Reader.CurrentTime.Minutes}:{mp3Reader.CurrentTime.Seconds}/{mp3Reader.TotalTime.Minutes}:{mp3Reader.TotalTime.Seconds}";
            }
            private set { }
        }
        public int timer
        {
            get
            {
                return (int)mp3Reader.CurrentTime.TotalSeconds;
            }
            set 
            {
                mp3Reader.CurrentTime = mp3Reader.CurrentTime.Add(TimeSpan.FromSeconds(value - timer));
            }
        }

        public Player(Disc disc)
        {
            playerButtonImagePath = @"Resources/Images/StartButton.png";
            this.disc = disc;
            var filePath = App.dbFilesPath + "/Music/" + disc.Music;
            var stream = new FileStream(filePath, FileMode.Open);
            mp3Reader = new Mp3FileReader(stream);
            waveOut = new WaveOut();
            waveOut.Init(mp3Reader);
        }

        public void CloseReader()
        {
            if (waveOut != null)
            {
                if (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Stop();
                }
                waveOut.Dispose();
                waveOut = null;
            }
            if (mp3Reader != null)
            {
                mp3Reader.Dispose();
                mp3Reader = null;
            }
        }
    }
}