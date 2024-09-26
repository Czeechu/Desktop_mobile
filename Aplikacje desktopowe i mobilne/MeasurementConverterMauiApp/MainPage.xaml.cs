using System;
using System.ComponentModel;

namespace MeasurementConverterMauiApp
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private string fromUnit;
        private string toUnit;
        private double inputValue;
        private string result;

        public string FromUnit
        {
            get { return fromUnit; }
            set
            {
                fromUnit = value;
                OnPropertyChanged(nameof(FromUnit));
            }
        }

        public string ToUnit
        {
            get { return toUnit; }
            set
            {
                toUnit = value;
                OnPropertyChanged(nameof(ToUnit));
            }
        }

        public double InputValue
        {
            get {return inputValue; }
            set
            {
                inputValue = value;
                OnPropertyChanged(nameof(InputValue));
            }
        }

        public string Result
        {
            get {return result; } 
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public MainPage()
        {
            
            InitializeComponent();
            BindingContext = this;

            FromUnit = "m";
            ToUnit = "cm";
        }

        private void OnConvertButtonClicked(object sender, EventArgs e)
        {
            double convertedValue = 0;

            if (FromUnit == "m")
            {
                if (ToUnit == "cm") convertedValue = InputValue * 100;
                else if (ToUnit == "mm") convertedValue = InputValue * 1000;
                else if (ToUnit == "km") convertedValue = InputValue / 1000;
                else convertedValue = InputValue;
            }
            else if (FromUnit == "cm")
            {
                if (ToUnit == "m") convertedValue = InputValue / 100;
                else if (ToUnit == "mm") convertedValue = InputValue * 10;
                else if (ToUnit == "km") convertedValue = InputValue / 100000;
                else convertedValue = InputValue;
            }
            else if (FromUnit == "mm")
            {
                if (ToUnit == "m") convertedValue = InputValue / 1000;
                else if (ToUnit == "cm") convertedValue = InputValue / 10;
                else if (ToUnit == "km") convertedValue = InputValue / 1000000;
                else convertedValue = InputValue;
            }
            else if (FromUnit == "km")
            {
                if (ToUnit == "m") convertedValue = InputValue * 1000;
                else if (ToUnit == "cm") convertedValue = InputValue * 100000;
                else if (ToUnit == "mm") convertedValue = InputValue * 1000000;
                else convertedValue = InputValue;
            }

            Result = $"{convertedValue} {ToUnit}";
        }
        
    }
}
