using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
    public class SearchCommand:ICommand
    {
        public WeatherVM VM { get; set; }

        public event EventHandler? CanExecuteChanged;

        public SearchCommand(WeatherVM vm)
        {
            //Assign the weather view model instance as default
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            //The parameter is the value inserted by the user to search
            string query = parameter as string;

            //If the parameter is null or white space, return false and disable the button, otherwise return true
            return string.IsNullOrWhiteSpace(query) ? false : true;
        }

        public void Execute(object? parameter)
        {
            //Execute the query to auto complete the selected city
            VM.MakeQuery();
        }
    }
}
