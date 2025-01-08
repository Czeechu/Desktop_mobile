using Microsoft.Maui.Controls;
using Quiz.Views;

namespace Quiz
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}
