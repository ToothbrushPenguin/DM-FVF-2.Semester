using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using FjernVarmeFyn.Persistance;
using FjernVarmeFyn.ViewModels;
using FjernVarmeFyn.Models;
using FjernVarmeFyn.Views;

namespace FjernVarmeFyn
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        private void ConfigureServices(ServiceCollection services)
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=feedbacktest;Trusted_Connection=True;TrustServerCertificate=true";

            services.AddSingleton<IRepository<Feedback>>(provider => new FeedbackRepository(connectionString));  // Repository
            services.AddSingleton<FeedbackViewModel>(); // FeedbackViewModel
            services.AddSingleton<MainViewModel>(); // MainViewModel
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();


            MainWindow mainWindow = new MainWindow
            {
                DataContext = ServiceProvider.GetRequiredService<MainViewModel>()
            };
        }
    }

}
