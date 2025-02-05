using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableReservation
{
    internal class Table : BindableObject
    {
        public string TableAutomationId { get; set; }

        private ObservableCollection<int> hours;
        public ObservableCollection<int> Hours
        {
            get { return hours; }
            set { hours = value; OnPropertyChanged(); }
        }

        public Table(string tableAutomationId)
        {
            TableAutomationId = tableAutomationId;
            Hours = new ObservableCollection<int>();
        }

        public void Reserve(int hour)
        {
            Hours.Add(hour);
        }

        public ObservableCollection<int> PrintReservedHours()
        {
            return Hours;
        }
    }
}
