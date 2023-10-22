using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.ViewModel.Helpers
{
    public class AccuWeatherHelper
    {
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string AUTOCOMPLETE_ENDPOINT = "/locations/v1/cities/autocomplete?apikey={0}&q={1}&language=it-IT";
        public const string API_KEY = "OVTXLxbNzHMcEJ8G8QpDqUaWYusMFiIq";
    }
}
