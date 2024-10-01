using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MinecraftMusicUi.Model;

namespace MinecraftMusicUi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Random random = new Random();
        public static MinecraftDiscsEntities db = new MinecraftDiscsEntities();
    }
}
