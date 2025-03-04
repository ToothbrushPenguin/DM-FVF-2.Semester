using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FjernVarmeFyn.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        LoginFrame frame;
        public Login(LoginFrame loginFrame)
        {
            InitializeComponent();
            this.DataContext = loginFrame;
            frame = loginFrame;
        }

        private void OpretBruger_Click(object sender, RoutedEventArgs e)
        {
            
            frame.PageHolder.Content = new BrugerOprettelse(frame);
        }

        private void GlemtKode_Click(object sender, RoutedEventArgs e)
        {
            frame.PageHolder.Content = new GlemtAdgangskode(frame);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            frame.Close();
        }
    }
}
