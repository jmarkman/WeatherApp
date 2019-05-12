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

        /// <summary>
        /// Creates a proper url source for the weather status image XAML node with the <see cref="Model.WeatherModel.Icon"/> property
        /// and the base url provided by OpenWeatherMap for their image icons
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>The url of the weather status icon as a string</returns>
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
