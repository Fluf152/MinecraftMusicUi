using NAudio.Codecs;
using NAudio.Vorbis;
using NAudio.Wave;
using NVorbis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftMusicUi.AudioClasses
{
    internal class VorbisPlayer
    {

        public VorbisWaveReader reader;
        public WaveOut player;
        public VorbisPlayer(string path)
        {
            reader = new VorbisWaveReader(path);
            player = new WaveOut();
            player.Init(reader);
        }
        public void Play()
        {
            reader.CurrentTime = TimeSpan.Zero;
            player.Play();
        }
    }
}
