using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;
using SportovniKlub.Interfaces;
using SportovniKlub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportovniKlub
{
    internal class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageService _messageService;

        public NavigationService(IServiceProvider serviceProvider, IMessageService messageService) 
        {
            _serviceProvider = serviceProvider;
            _messageService = messageService;
        }


        public void ShowAddOsobyWindow()
        {
            throw new NotImplementedException();
        }

        public void ShowAddTreninkWindow()
        {
            try
            {
                var window = _serviceProvider.GetRequiredService<AddTreninkWindow>();
                window.Show();
            }
            catch (OracleException ex)
            {
                _messageService.ShowMessage(ex.Message);
                Clipboard.SetText(ex.StackTrace);
            }
            catch (Exception ex)
            {
                _messageService.ShowMessage(ex.Message);
                Clipboard.SetText(ex.StackTrace);
            }
        }

        public void ShowAddTymyWindow()
        {
            throw new NotImplementedException();
        }

        public void ShowOsobyWindow()
        {
            throw new NotImplementedException();
        }

        public void ShowTreninkyWindow()
        {
            try
            {
                var scope = App.ServiceProvider.CreateScope();

                var viewModel = scope.ServiceProvider.GetRequiredService<TreninkyViewModel>();

                var window = scope.ServiceProvider.GetRequiredService<TreninkyWindow>();
                window.DataContext = viewModel;

                window.Closed += (s, e) => scope.Dispose();

                window.Show();
            }
            catch (OracleException ex)
            {
                _messageService.ShowMessage(ex.Message);
                Clipboard.SetText(ex.StackTrace);
            }
            catch (Exception ex)
            {
                _messageService.ShowMessage(ex.Message);
                Clipboard.SetText(ex.StackTrace);
            }
        }

        public void ShowTymyWindow()
        {
            throw new NotImplementedException();
        }
    }
}
