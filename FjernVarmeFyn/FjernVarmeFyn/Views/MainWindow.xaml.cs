using FjernVarmeFyn.ViewModels;
using FjernVarmeFyn.Views;
using Microsoft.Extensions.DependencyInjection;
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
using FjernVarmeFyn.ViewModels;

namespace FjernVarmeFyn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private readonly MainViewModel _mainViewModel;
        private Button _selectedButton = null;

        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            MainFrame.Navigate(new UserSendFeedback());
            _mainViewModel = App.ServiceProvider.GetRequiredService<MainViewModel>();
            DataContext = _mainViewModel;
            if (_mainViewModel == null)
            {
                MessageBox.Show("_mainViewModel is NULL!");
            }

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
                AdminFeedbackReview adminFeedbackReview = new AdminFeedbackReview();
                adminFeedbackReview.DataContext = _mainViewModel.FeedbackViewModel;
                MainFrame.Navigate(adminFeedbackReview);
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
                UserSendFeedback userSendFeedback = new UserSendFeedback();
                userSendFeedback.DataContext = _mainViewModel.FeedbackViewModel;
                MainFrame.Navigate(userSendFeedback);
                
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
                UserSettingsPage userSettingsPage = new UserSettingsPage();
                userSettingsPage.DataContext = _mainViewModel;
                MainFrame.Navigate(userSettingsPage);
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
                DomainInfo domainInfo = new DomainInfo();
                domainInfo.DataContext = _mainViewModel;
                MainFrame.Navigate(domainInfo);
               
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
                ListOfSystems listOfSystems = new ListOfSystems();
                listOfSystems.DataContext = _mainViewModel;
                MainFrame.Navigate(listOfSystems);
               
            }
        }
    }
}