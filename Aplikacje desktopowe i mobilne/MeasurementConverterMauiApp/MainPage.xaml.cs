using System.Collections.ObjectModel;

namespace MeasurementConverterMauiApp
{
    public partial class MainPage : ContentPage
    {

        public List<string> UnitsCollection { get; set; }

        private string firstUnits;

        public string FirstUnits
        {
            get { return firstUnits; }
            set
            {
                firstUnits = value;
                OnPropertyChanged();
            }
        }

        public string Calculate { get; set; }

        public MainPage()
        {
            UnitsCollection = new List<string>();
            UnitsCollection.Add("milimetry");
            UnitsCollection.Add("centymetry");
            UnitsCollection.Add("metry");
            UnitsCollection.Add("kilometry");

            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            UnitsCollection.Add(Calculate);
        }
    }

}
