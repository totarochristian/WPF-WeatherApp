using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel.Helpers
{
    public class AccuWeatherHelper
    {
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language=it-IT";
        public const string CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}&language=it-IT";
        public const string API_KEY = "OVTXLxbNzHMcEJ8G8QpDqUaWYusMFiIq";

        public static List<City> GetCities(string query)
        {
            List<City> cities = new List<City>();

            string url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query);

            return cities;
        }
    }
}
