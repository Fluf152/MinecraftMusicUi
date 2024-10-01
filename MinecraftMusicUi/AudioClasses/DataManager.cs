using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftMusicUi.Model;

namespace MinecraftMusicUi.AudioClasses
{
    public class DataManager
    {
        public List<Player> players;

        public void LoadPlayers()
        {
            players = new List<Player>();
            var discs = App.db.Disc.ToList();
            foreach (var disc in discs)
            {
                players.Add(new Player(disc));
            }
        }
    }
}
