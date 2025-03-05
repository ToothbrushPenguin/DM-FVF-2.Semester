using FjernVarmeFyn.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FjernVarmeFyn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            MainFrame.Navigate(new UserSendFeedback());
        }

        private void FeedBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new FeedbackPage());
        }

        private void SendtFeedBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UserSendFeedback());
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UserSettingsPage());
        }
        private void Domain_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DomainInfo());
        }

        private void System_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListOfSystems()); 
        }
    }
}