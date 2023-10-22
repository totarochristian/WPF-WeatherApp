using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public const string API_KEY = "XSvHCbVTUTBS2BVtOz8UNEMF9PhPAa6W";

        public static async Task<List<City>> GetCities(string query)
        {
            List<City> cities = new List<City>();
            
            try
            {
                string url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query);

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    string json = await response.Content.ReadAsStringAsync();

                    //If the status isn't success, generate exception
                    response.EnsureSuccessStatusCode();

                    cities = JsonConvert.DeserializeObject<List<City>>(json);
                }
            }
            catch(HttpRequestException hhtpReqEx)
            {
                Console.WriteLine("[AccuWeatherHelper][GetCities] HttpRequestException: " + hhtpReqEx.Message);
            }catch(Exception ex)
            {
                Console.WriteLine("[AccuWeatherHelper][GetCities] Exception: " + ex.Message);
            }

            return cities;
        }

        public static async Task<CurrentConditions> GetCurrentConditions(string cityKey)
        {
            CurrentConditions currentConditions = new CurrentConditions();

            try
            {
                string url = BASE_URL + string.Format(CONDITIONS_ENDPOINT, cityKey, API_KEY);

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    string json = await response.Content.ReadAsStringAsync();

                    //If the status isn't success, generate exception
                    response.EnsureSuccessStatusCode();

                    currentConditions = (JsonConvert.DeserializeObject<List<CurrentConditions>>(json)).FirstOrDefault();
                }
            }
            catch (HttpRequestException hhtpReqEx)
            {
                Console.WriteLine("[AccuWeatherHelper][GetCurrentConditions] HttpRequestException: " + hhtpReqEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[AccuWeatherHelper][GetCurrentConditions] Exception: " + ex.Message);
            }

            return currentConditions;
        }
    }
}
