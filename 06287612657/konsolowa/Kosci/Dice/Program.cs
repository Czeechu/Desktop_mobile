class Program
{
    static void Main(string[] args)
    {
        bool grajPonownie;

        do
        {
            int liczbaKostek = PobierzLiczbeKostek();
            int[] wyniki = RzucKostkami(liczbaKostek);
            WypiszWyniki(wyniki);
            int punkty = PoliczPunkty(wyniki);
            Console.WriteLine($"Łączna liczba punktów: {punkty}");

            grajPonownie = CzyGrajPonownie();
        } while (grajPonownie);

        static int PobierzLiczbeKostek()
        {
            int liczba;
            do
            {
                Console.Write("Podaj liczbę kostek (3-10): ");
                if (!int.TryParse(Console.ReadLine(), out liczba) || liczba < 3 || liczba > 10)
                {
                    Console.WriteLine("Liczba nie jest z przedziału (3-10)");
                }
            } while (liczba < 3 || liczba > 10);

            return liczba;
        }

        static int[] RzucKostkami(int liczbaKostek)
        {
            Random rand = new Random();
            int[] wynik = new int[liczbaKostek];

            for(int i = 0; i < liczbaKostek; i++)
            {
                wynik[i] = rand.Next(1, 7);
            }
            return wynik;
        }

        static void WypiszWyniki(int[] wyniki)
        {
            for (int i = 0; i < wyniki.Length; i++)
            {
                Console.WriteLine($"Kostka {i + 1}: {wyniki[i]}");
            }
        }

        static int PoliczPunkty(int[] wyniki)
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

        static bool CzyGrajPonownie()
        {
            Console.Write("Czy chcesz zagrać ponownie? (t/n): ");
            char odpowiedz = Console.ReadKey().KeyChar;
            Console.WriteLine(); 
            return odpowiedz == 't';
        }
    }    
}

//************************************************
//nazwa: PobierzLiczbeKostek
//opis: Funkcja pobiera od użytkownika liczbę kostek do rzutu w zakresie od 3 do 10.
//parametry: brak
//zwracany typ i opis: int - liczba kostek wprowadzona przez użytkownika
//autor: 06
//************************************************

//************************************************
//nazwa: RzucKostkami
//opis: Funkcja generuje wyniki rzutu kostkami, zwracając tablicę z wartościami wyników.
//parametry: 
//int liczbaKostek - liczba kostek do rzutu
//zwracany typ i opis: int[] - tablica z wynikami rzutu kostkami
//autor: 06
//************************************************

//************************************************
//nazwa: WypiszWyniki
//opis: Funkcja wypisuje na konsolę wyniki rzutu kostkami.
//parametry: 
//int[] wyniki - tablica z wynikami rzutu
//zwracany typ i opis: brak
//autor: 06
//************************************************

//************************************************
//nazwa: PoliczPunkty
//opis: Funkcja oblicza i zwraca łączną liczbę punktów na podstawie wyników rzutu kostkami, przyznając punkty za powtarzające się wartości.
//parametry: 
//int[] wyniki - tablica z wynikami rzutu kostkami
//zwracany typ i opis: int - łączna liczba punktów
//autor: 06
//************************************************

//************************************************
//nazwa: CzyGrajPonownie
//opis: Funkcja pyta użytkownika, czy chce zagrać ponownie, i zwraca odpowiedź.
//parametry: brak
//zwracany typ i opis: bool - true jeśli użytkownik chce grać ponownie, false w przeciwnym razie
//autor: 06
//************************************************
