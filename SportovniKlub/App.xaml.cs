using SportovniKlub.Interfaces;
using SportovniKlub.Services;
using SportovniKlub.TablesHandlers;
using SportovniKlub.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SportovniKlub
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ITymyService TymyService { get; private set; }
        public ITreninkyService TreninkyService { get; private set; }
        public IOsobyService OsobyService { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var db = new OracleDatabase(); 
            TymyService = new TymyService(db);
            TreninkyService = new TreninkyService(db);  
            OsobyService = new OsobyService(db);
        }
    }
}
