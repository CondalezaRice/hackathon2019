using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MKUltra.Model
{
    public class CumulativeStatistics : BaseStatistics, INotifyPropertyChanged
    {
        private int _totalGamesPlayed = 0;
        public int TotalGamesPlayed
        {
            get => _totalGamesPlayed;
            set => SetProperty(ref _totalGamesPlayed, value);
        }

        private int _gamesWon = 0;
        public int GamesWon
        {
            get => _gamesWon;
            set => SetProperty(ref _gamesWon, value);
        }

        private int _gamesLost = 0;
        public int GamesLost
        {
            get => _gamesLost;
            set => SetProperty(ref _gamesLost, value);
        }

    }
}
