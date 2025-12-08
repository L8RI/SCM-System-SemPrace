using Microsoft.Extensions.DependencyInjection;
using SportovniKlub.Interfaces;
using SportovniKlub.Mappers;
using SportovniKlub.Models;
using SportovniKlub.Repositories;
using SportovniKlub.Services;
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

        public static IServiceProvider ServiceProvider { get; private set; }   

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            services.AddScoped<IUnitOfWork>(p => new OracleUnitOfWork(connectionString));

            //Repositories:
            services.AddScoped<TreninkyRepository>();
            services.AddScoped<TymyRepository>();
            services.AddScoped<SportovniDisciplinyRepository>();
            services.AddScoped<SponzoriRepository>();
            services.AddScoped<TreneriRepository>();
            services.AddScoped<OsobyRepository>();
            services.AddScoped<TypyTreninkuRepository>();

            //Services:
            services.AddScoped<INavigationService, NavigationService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<ITreninkyService, TreninkyService>();
            services.AddScoped<ITymyService, TymyService>();
            services.AddScoped<ITreneriService, TreneriService>();
            services.AddScoped<ISportovniDisciplinaService, DisciplinaService>();
            services.AddScoped<IOsobyService, OsobyService>();
            services.AddScoped<ITypyTreninkuService, TypyTreninkuService>();


            //ViewModels:
            services.AddTransient<TreninkyViewModel>();
            services.AddTransient<TymyViewModel>();
            services.AddTransient<OsobyViewModel>();
            services.AddTransient<AddTreninkViewModel>();
            services.AddTransient<MainViewModel>();

            //Views:
            services.AddTransient<TymyWindow>();
            services.AddTransient<TreninkyWindow>();
            services.AddTransient<OsobyWindow>();
            services.AddTransient<AddTreninkWindow>();

            //Mappers:
            services.AddScoped<ITreninkMapper, TreninkMapper>();
            services.AddScoped<ITymyMapper, TymyMapper>();
            services.AddScoped<IOsobyMapper, OsobyMapper>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
