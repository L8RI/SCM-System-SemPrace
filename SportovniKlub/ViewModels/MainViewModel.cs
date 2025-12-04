using SportovniKlub.Interfaces;
using SportovniKlub.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportovniKlub.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private OracleDatabase db;

        public MainViewModel(OracleDatabase db)
        {
            this.db = db;
        }

        public TymyViewModel TymyVM { get; }

        public MainViewModel()
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
