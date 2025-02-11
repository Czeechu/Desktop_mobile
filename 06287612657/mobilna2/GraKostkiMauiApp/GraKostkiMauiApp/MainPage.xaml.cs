namespace GraKostkiMauiApp
{
    public partial class MainPage : ContentPage
    {
        private Random rand = new Random();
        private int sumaPunktow;

        public MainPage()
        {
            InitializeComponent();
        }

        private void RzucKostkamiGra(object sender, EventArgs e)
        {
            int liczbaKostek = 5;
            int[] wyniki = RzucKostkami(liczbaKostek);
            WypiszWyniki(wyniki);
            sumaPunktow = PoliczPunkty(wyniki);
            WynikGryLabel.Text = $"Wynik gry: {sumaPunktow}";
        }

        private int[] RzucKostkami(int liczbaKostek)
        {
            int[] wynik = new int[liczbaKostek];

            for (int i = 0; i < liczbaKostek; i++)
            {
                wynik[i] = rand.Next(1, 7);
            }
            return wynik;
        }

        private void WypiszWyniki(int[] wyniki)
        {
            Image[] zdjecia = { k1, k2, k3, k4, k5 };

            for (int i = 0; i < wyniki.Length; i++)
            {
                zdjecia[i].Source = $"k{wyniki[i]}.jpg";
                Console.WriteLine($"Kostka {i + 1}: {wyniki[i]}");
            }

            string wynikTekst = "Wynik tego losowania: ";

            for (int i = 0; i < wyniki.Length; i++)
            {
                wynikTekst += wyniki[i];

                if (i < wyniki.Length - 1)
                {
                    wynikTekst += ", ";
                }
            }

            WynikLabel.Text = wynikTekst;
        }

        private int PoliczPunkty(int[] wyniki)
        {
            int[] licznik = new int[7];

            foreach (int wynik in wyniki)
            {
                licznik[wynik]++;
            }

            int punkty = 0;

            for (int i = 1; i <= 6; i++)
            {
                if (licznik[i] > 1)
                {
                    punkty += i * licznik[i];
                }
            }
            return punkty;
        }

        private void ResetujWynik(object sender, EventArgs e)
        {
            sumaPunktow = 0;
            WynikLabel.Text = "Wynik tego losowania: ";
            WynikGryLabel.Text = "Wynik gry: ";

            Image[] zdjecia = { k1, k2, k3, k4, k5 };
            for (int i = 0; i < zdjecia.Length; i++)
            {
                zdjecia[i].Source = "question.jpg"; 
            }
        }
    }
}