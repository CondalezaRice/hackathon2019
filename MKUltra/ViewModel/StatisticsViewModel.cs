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
    public class StatisticsViewModel : ViewModelBase
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
    }
}
