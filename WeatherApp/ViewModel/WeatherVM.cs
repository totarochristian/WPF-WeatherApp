using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

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
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            //Trigger the event of specified property changed
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
