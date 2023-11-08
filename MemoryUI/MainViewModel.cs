using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryUI
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CardBase> _cards;
        private int colAmount;

        public int ColAmount { get { return colAmount; } set { colAmount = value; } }

        public ObservableCollection<CardBase> Cards
        {
            get { return _cards; }
            set
            {
                _cards = value;
                OnPropertyChanged(nameof(Cards));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
