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
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;
        public RelayCommand OpenTreninkyCommand { get; }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            OpenTreninkyCommand = new RelayCommand(treninky =>
            {
                OpenTreninky();
            });
        }

        private void OpenTreninky()
        {
            _navigationService.ShowTreninkyWindow();    
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
