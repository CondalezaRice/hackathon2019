using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MKUltra
{
    public class SecondsToTimeStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double? time = value as double?;

            if (time != null)
            {
                var minutes = Math.Floor(time.GetValueOrDefault()/60);
                var seconds = time % 60;
                return minutes.ToString().PadLeft(2,'0') + ":" + seconds.ToString().PadLeft(2, '0');
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

    }
}