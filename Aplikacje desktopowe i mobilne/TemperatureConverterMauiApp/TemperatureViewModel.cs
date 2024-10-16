using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverterMauiApp
{
    public class TemperatureViewModel : BindableObject
    {
        public ObservableCollection<string> Units { get; set; }

		private string selectedUnit;

		public string SelectedUnit
        {
			get { return selectedUnit; }
			set { selectedUnit = value; OnPropertyChanged(); }
		}

		private string unitMessgae;

		public string UnitMessage
		{
			get { return unitMessgae; }
			set { unitMessgae = value; OnPropertyChanged(); }
		}

		private string unitConverter;

		public string UnitConverter
        {
			get { return unitConverter; }
			set { unitConverter = value;  OnPropertyChanged(); }
		}

		public Command CalculateCommand { get; set; }

		public TemperatureViewModel()
		{
			Units = new ObservableCollection<string> 
			{ "C", 
				"F" 
			};
			CalculateCommand = new Command(OnCalculate);

        }

		private void OnCalculate()
		{
			if(double.TryParse(UnitConverter, out double temperature))
			{
				if (SelectedUnit == "C")
				{
					double farenheit = Math.Round((temperature - 32) * (5.0 / 9.0), 0);
					UnitMessage = $"{temperature} F do {farenheit} C";
				}
				else if (SelectedUnit == "F")
				{
                    double celsius = Math.Round(((temperature * 1.8) + 32), 0);
                    UnitMessage = $"{temperature} C do {celsius} F";
                }
            }
		}
    }
}