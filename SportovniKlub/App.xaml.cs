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
        private readonly string connectionString = "User Id=st72491;Password=Znahar137273;" +
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=FEI-SQL3.UPCEUCEBNY.CZ)(PORT=1521))(CONNECT_DATA=(SID=BDAS)));";

        public ITymyService TymyService { get; private set; }
        public ITreninkyService TreninkyService { get; private set; }
        public IOsobyService OsobyService { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var db = new OracleDatabase(); 

            TymyService = new TymyService(connectionString);
            TreninkyService = new TreninkyService(db);  
            OsobyService = new OsobyService(db);
        }
    }
}
