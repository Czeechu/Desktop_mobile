using Android.Media;
using System.ComponentModel;

namespace FirstMauiApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        
        }

        async private void OnCounterClicked(object sender, EventArgs e)
        {

            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            if(count % 2 == 0)
            {
                await Icon.RotateTo(2700, 30000);
                Icon.Rotation = 0;

                await Tekst.ScaleTo(300, 500);
                Tekst.Rotation = 0;   
            }
            else
            {
                await Tekst.ScaleTo(1, 500);
            }
            
            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
