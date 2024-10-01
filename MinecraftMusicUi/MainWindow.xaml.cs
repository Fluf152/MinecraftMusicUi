using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Security.Cryptography;
using NAudio.Wave;
using System.IO;
using MinecraftMusicUi.Model;
using MinecraftMusicUi.AudioClasses;
using System.Windows.Media;
using NAudio.CoreAudioApi;
using NAudio.Vorbis;
using System.Threading;

namespace MinecraftMusicUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataManager dataManager;
        List<VorbisPlayer> minecraftSounds;
        public MainWindow()
        {
            InitializeComponent();
            dataManager = new DataManager();
            dataManager.LoadPlayers();
            LoadMinecraftSounds();
            DiscsListView.ItemsSource = dataManager.players;
        }

        public void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            DiscsListView.ItemsSource = null;
            DiscsListView.ItemsSource = dataManager.players.Where(x => x.disc.Title.ToLower().Contains(SearchTextBox.Text)).ToList();
        }

        public void PlayerButtonClick(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var discId = ((Disc)((Player)btn.DataContext).disc).Id;
            var player = dataManager.players.First(x => x.disc.Id == discId).waveOut;
            switch (player.PlaybackState)
            {
                case PlaybackState.Playing:
                    {
                        player.Pause();
                        SetButtonImage(btn, @"Resources/Images/StartButton.png");
                        break;
                    }
                case PlaybackState.Stopped:
                    {
                        player.Play();
                        SetButtonImage(btn, @"Resources/Images/PauseButton.png");
                        break;
                    }
                case PlaybackState.Paused:
                    {
                        player.Play();
                        SetButtonImage(btn, @"Resources/Images/PauseButton.png");
                        break;
                    }
            }
        }

        private void SetButtonImage(Button button, string path)
        {
            button.Content = new Image
            {
                Source = new BitmapImage(new Uri(path, UriKind.Relative))
            };
        }

        private void JukeBoxButtonClick(object sender, RoutedEventArgs e)
        {
            int count = minecraftSounds.Count;
            if (count == 0)
            {
                return;
            }
            try
            {
                var rand = App.random.Next(0, count);
                if (minecraftSounds[count - 1].reader == null)
                {
                    return;
                }
                minecraftSounds[rand].player.Play();
                minecraftSounds[rand].reader.Position = 0;
            }
            catch (Exception ex) { }
        }
        private void LoadMinecraftSounds()
        {
            minecraftSounds = new List<VorbisPlayer>();
            for (var i = 1; i <= 7; i++)
            {
                minecraftSounds.Add(new VorbisPlayer($@"Resources/Sounds/MinecraftNotes/{i}.ogg"));
            }
        }
    }
}