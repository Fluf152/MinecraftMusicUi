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
        List<Player> _discsListViewinstance;
        Timer timer;
        public MainWindow()
        {
            InitializeComponent();
            dataManager = new DataManager();
            dataManager.LoadPlayers();
            LoadMinecraftSounds();
            _discsListViewinstance = dataManager.players;
            var timerCallBack = new TimerCallback(ListViewUpdate);
            timer = new Timer(timerCallBack, 0, 0, 1500);


        }

        public void ListViewUpdate(object value)
        {
            this.Dispatcher.Invoke(new Action(() => {
                DiscsListView.ItemsSource = null;
                DiscsListView.ItemsSource = _discsListViewinstance;
            }));
        }

        public void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            _discsListViewinstance = dataManager.players.Where(x => x.disc.Title.ToLower().Contains(SearchTextBox.Text)).ToList();
        }

        public void PlayerButtonClick(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var discId = ((Disc)((Player)btn.DataContext).disc).Id;
            var player = dataManager.players.First(x => x.disc.Id == discId);
            string path = "";
            switch (player.waveOut.PlaybackState)
            {
                case PlaybackState.Playing:
                    {
                        player.waveOut.Pause();
                        path = @"Resources/Images/StartButton.png";
                        break;
                    }
                case PlaybackState.Stopped:
                    {
                        player.waveOut.Play();
                        path = @"Resources/Images/PauseButton.png";
                        break;
                    }
                case PlaybackState.Paused:
                    {
                        player.waveOut.Play();
                        path = @"Resources/Images/PauseButton.png";
                        break;
                    }
            }
            player.playerButtonImagePath = path;
            SetButtonImage(btn, path);
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
                minecraftSounds[rand].Play();
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