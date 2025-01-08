using Quiz.ViewModels;

namespace Quiz.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new QuizViewModel();
        }
    }
}
