using MinecraftMusicUi.Model;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var slid = new Slider();
            this.disc = disc;
            var stream = new MemoryStream(disc.Music);
            mp3Reader = new Mp3FileReader(stream);
            waveOut = new WaveOut();
            waveOut.Init(mp3Reader);
        }

        public void SetPlayerTime(int time)
        {
            //mp3Reader.CurrentTime.Add()
        }
    }
}