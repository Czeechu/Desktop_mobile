using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ReservationTables
{
    public class ReservationViewModel : BindableObject
    {
        // Przechowuje informacje o przyciskach, ich kolorach i tekstach
        public ObservableCollection<ButtonState> ButtonStates { get; set; }

        // Komenda rezerwacji
        public ICommand ReserveCommand { get; }

        public ReservationViewModel()
        {
            // Tworzymy kolekcję 5 przycisków
            ButtonStates = new ObservableCollection<ButtonState>
            {
                new ButtonState(),
                new ButtonState(),
                new ButtonState(),
                new ButtonState(),
                new ButtonState()
            };

            // Komenda rezerwacji
            ReserveCommand = new Command<int>(ReserveTable);
        }

        // Metoda rezerwacji, zmienia stan przycisku
        private void ReserveTable(int tableIndex)
        {
            var buttonState = ButtonStates[tableIndex];
            if (!buttonState.IsReserved)
            {
                // Zarezerwuj stolik (zmiana stanu przycisku)
                buttonState.IsReserved = true;

                // Zaktualizuj kolor i tekst przycisku
                buttonState.Color = Color.Green;
                buttonState.Text = "Zarezerwowany";
            }
        }
    }

    // Klasa reprezentująca stan każdego przycisku
    public class ButtonState : BindableObject
    {
        private bool _isReserved;
        private Color _color = Color.Gray;
        private string _text = "Zarezerwuj";

        public bool IsReserved
        {
            get => _isReserved;
            set
            {
                _isReserved = value;
                OnPropertyChanged();
            }
        }

        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                OnPropertyChanged();
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }
    }
}
