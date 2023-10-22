using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        private string query;

        public string Query
        {
            get { return query; }
            set { 
                query = value;
                OnPropertyChanged("Query");
            }
        }

        public ObservableCollection<City> Cities { get; set; }

        private CurrentConditions currentConditions;

        public CurrentConditions CurrentConditions
        {
            get { return currentConditions; }
            set { 
                currentConditions = value;
                OnPropertyChanged("CurrentConditions");
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set { 
                selectedCity = value;
                OnPropertyChanged("SelectedCity");
            }
        }

        public SearchCommand SearchCommand { get; set; }


        public WeatherVM()
        {
            //If the application is not running
            if(DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                //initialize an example selected city
                SelectedCity = new City
                {
                    LocalizedName = "Fiorano Modenese"
                };
                //Initialize an example current conditions
                CurrentConditions = new CurrentConditions
                {
                    WeatherText = "Parzialmente nuvoloso",
                    //Initialize an example temperature
                    Temperature = new Temperature
                    {
                        Metric = new Units
                        {
                            Value = 19
                        }
                    }
                };
            }

            //Initialize the search command passing this instance of weather view model
            SearchCommand = new SearchCommand(this);

            //Initialize the observable collection at the creation of the class because could be initialized only one time
            Cities = new ObservableCollection<City>();
        }

        public async void MakeQuery()
        {
            var cities = await AccuWeatherHelper.GetCities(Query);

            //The observable collection couldn't be re-initialized but could be cleared and then re-filled with new data
            Cities.Clear();
            foreach(var city in cities)
            {
                Cities.Add(city);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            //Trigger the event of specified property changed
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
