namespace SimpleCalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!int.TryParse(firstNumberEntry.Text, out int firstNumber))
            {
                // błąd
                resultLabel.Text = "Niepoprawna pierwsza liczba";
                resultLabel.TextColor = new Color(255, 0, 0);
            }
            if (!int.TryParse(secondNumberEntry.Text, out int secondNumber))
            {
                // błąd
                resultLabel.Text = "Niepoprawna druga liczba";
                resultLabel.TextColor = new Color(255, 0, 0);
            }

            int result = 0;

            if (operationAddRadioButton.IsChecked)
            {
                result = firstNumber + secondNumber;
            }
            else if (operationSubRadioButton.IsChecked)
            {
                result = firstNumber - secondNumber;
            }
            else if (operationMulRadioButton.IsChecked)
            {
                result = firstNumber * secondNumber;
            }
            else if (operationDivRadioButton.IsChecked)
            {
                result = firstNumber / secondNumber;
            }

            resultLabel.Text = "Wynik operacji to " + result;
            resultLabel.TextColor = Colors.Green;
        }
    }
}