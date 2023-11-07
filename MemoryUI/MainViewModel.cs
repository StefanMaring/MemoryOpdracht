using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryUI
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<CardBase> _cards;
        private CardBase _card; 

        public List<CardBase> Cards
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
