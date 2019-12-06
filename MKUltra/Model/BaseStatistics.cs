using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MKUltra.Model
{
    public class BaseStatistics : INotifyPropertyChanged
    {

        private double _totalCharactersTyped = 0;
        public double TotalCharactersTyped
        {
            get => _totalCharactersTyped;
            set => SetProperty(ref _totalCharactersTyped, value);
        }

        private double _charactersCorrect = 0;
        public double CharactersCorrect
        {
            get => _charactersCorrect;
            set => SetProperty(ref _charactersCorrect, value);
        }

        private double _charactersIncorrect = 0;
        public double CharactersIncorrect
        {
            get => _charactersIncorrect;
            set => SetProperty(ref _charactersIncorrect, value);
        }

        private double _totalWords = 0;
        public double TotalWords
        {
            get => _totalWords;
            set => SetProperty(ref _totalWords, value);
        }

        private double _totalSecondsPlayed;
        public double TotalSecondsPlayed
        {
            get => _totalSecondsPlayed;
            set => SetProperty(ref _totalSecondsPlayed, value);
        }

        //define percentage correct stuff
        private double _percentage_correct;
        public double Percentage_correct
        {
            get => _percentage_correct;
            set => SetProperty(ref _percentage_correct, value);
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
