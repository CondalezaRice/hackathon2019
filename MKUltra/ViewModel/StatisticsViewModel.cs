using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MKUltra.ViewModel
{
    public enum StatisticsType { Cumulative, SingleGame };
    public class StatisticsViewModel
    {
        public StatisticsType _statisticsType;
        public StatisticsType StatisticsType
        {
            get => _statisticsType;
            set => SetProperty(ref _statisticsType, value);
        }

        public StatisticsViewModel(StatisticsType statisticsType = StatisticsType.SingleGame)
        {
            _statisticsType = statisticsType;
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
