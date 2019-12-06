using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MKUltra.Model
{
    public class CumulativeStatistics : SingleGameStatistics, INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }

    }
}
