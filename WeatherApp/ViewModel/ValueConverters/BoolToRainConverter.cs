using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeatherApp.ViewModel.ValueConverters
{
    public class BoolToRainConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isRaining = (bool)value;

            if (isRaining)
            {
                switch (culture.Name)
                {
                    case "it-IT": return "Sta piovendo";
                    case "en-EN": return "Currently raining";
                }
            }
            else
            {
                switch (culture.Name)
                {
                    case "it-IT": return "Non sta piovendo";
                    case "en-EN": return "Currently not raining";
                }
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string isRaining = (string)value;

            if (isRaining.Equals("Sta piovendo") || isRaining.Equals("Currently raining"))
                return true;
            else if (isRaining.Equals("Non sta piovendo") || isRaining.Equals("Currently not raining"))
                return false;

            return null;
        }
    }
}
