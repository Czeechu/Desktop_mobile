using ReservationTables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationTables.VievModels
{
    internal class TableReservationVievModel : BindableObject
    {
        private ObservableCollection<int> hours;

        public ObservableCollection<int> Hours
        {
            get { return hours; }
            set { hours = value; OnPropertyChanged(); }
        }


        private Command chooseTableCommand;
        public Command ChooseTableCommand
        {
            get { return chooseTableCommand; }
            set { chooseTableCommand = value; }
        }

        private Command tableReservationCommand;
        public Command TableReservationComand
        {
            get { return tableReservationCommand; }
            set { tableReservationCommand = value; }
        }

        private Button prevTable;
        public Button PrevTable
        {
            get { return prevTable; }
            set { prevTable = value; OnPropertyChanged(nameof(PrevTable)); }
        }

        public string prevTableAutomationId { get; set; }

        private bool reservationLayoutVisible;
        public bool ReservationLayoutVisible
        {
            get { return reservationLayoutVisible; }
            set { reservationLayoutVisible = value; OnPropertyChanged(); }
        }

        private string bookerName;
        public string BookerName
        {
            get { return bookerName; }
            set { bookerName = value; OnPropertyChanged(); }
        }

        private string test;

        public string Test
        {
            get { return test; }
            set { test = value; OnPropertyChanged(); }
        }

        private int selectedDate;

        public int SelectedDate
        {
            get { return selectedDate; }
            set { selectedDate = value; OnPropertyChanged(); }
        }

        public void ShowReservedHours(List<Table> tables, bool add)
        {
            for (int i = 0; i < 4; i++)
            {
                if (tables[i].TableAutomationId == prevTableAutomationId)
                {
                    Test = " ";
                    if (add && Hours.Count() != 0)
                        tables[i].Reserve(SelectedDate);

                    foreach (int hour in tables[i].PrintReservedHours())
                    {
                        Test += hour + ", ";
                    }
                }
            }
        }

        public TableReservationVievModel()
        {
            Hours = new ObservableCollection<int>();
            for (int i = 8; i <= 21; i++)
            {
                Hours.Add(i);
            }

            List<Table> tables = new List<Table>
            {
                new Table("table1"),
                new Table("table2"),
                new Table("table3"),
                new Table("table4")
            };

            ChooseTableCommand = new Command<Button>(table =>
            {
                ReservationLayoutVisible = true;

                if (PrevTable != null)
                    PrevTable.Background = Colors.LightGrey;

                PrevTable = table;
                prevTableAutomationId = table.AutomationId;
                table.Background = Colors.Green;
                ShowReservedHours(tables, false);
            });

            TableReservationComand = new Command(() =>
            {
                ShowReservedHours(tables, true);
                RefreshHoursPicker(SelectedDate);
            });
        }

        public void RefreshHoursPicker(int hour)
        {
            Hours.Remove(hour);
        }
    }
}