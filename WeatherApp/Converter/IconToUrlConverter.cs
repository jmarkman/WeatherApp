using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeatherApp.Converter
{
    [ValueConversion(typeof(string), typeof(string))]
    public class IconToUrlConverter : IValueConverter
    {
        public static IconToUrlConverter Instance = new IconToUrlConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var imgUrl = "http://openweathermap.org/img/w/";
            string icon = (string)value;

            return $"{imgUrl}{icon}.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
