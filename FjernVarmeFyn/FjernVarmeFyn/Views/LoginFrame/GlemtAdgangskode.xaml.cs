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
    /// Interaction logic for GlemtAdgangskode.xaml
    /// </summary>
    public partial class GlemtAdgangskode : Page
    {
        private LoginFrame frame;
        public GlemtAdgangskode(LoginFrame loginFrame)
        {
            InitializeComponent();
            this.DataContext = loginFrame;
            frame = loginFrame;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            frame.PageHolder.Content = new Login(frame);
        }
    }
}
