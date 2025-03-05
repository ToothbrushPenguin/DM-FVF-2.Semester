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
        private Button _selectedButton = null;

        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            MainFrame.Navigate(new UserSendFeedback());
        }

        private void RewiewFeedBack_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedButton != null)
                _selectedButton.Background = Brushes.Black;

            // Set new button color
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                clickedButton.Background = Brushes.Red;
                _selectedButton = clickedButton;
                MainFrame.Navigate(new AdminFeedbackReview());
            }
        }

        private void FeedBack_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedButton != null)
                _selectedButton.Background = Brushes.Black;

            // Set new button color
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                clickedButton.Background = Brushes.Red;
                _selectedButton = clickedButton;
                MainFrame.Navigate(new UserSendFeedback());
            }
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedButton != null)
                _selectedButton.Background = Brushes.Black;

            // Set new button color
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                clickedButton.Background = Brushes.Red;
                _selectedButton = clickedButton;
                MainFrame.Navigate(new UserSettingsPage());
            }
        }
        private void Domain_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedButton != null)
                _selectedButton.Background = Brushes.Black;

            // Set new button color
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                clickedButton.Background = Brushes.Red;
                _selectedButton = clickedButton;
                MainFrame.Navigate(new DomainInfo());
            }
        }

        private void System_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedButton != null)
                _selectedButton.Background = Brushes.Black;

            // Set new button color
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                clickedButton.Background = Brushes.Red;
                _selectedButton = clickedButton;
                MainFrame.Navigate(new ListOfSystems());
            }
        }
    }
}