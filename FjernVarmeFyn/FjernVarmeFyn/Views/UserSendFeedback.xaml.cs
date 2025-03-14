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

using System.Collections.ObjectModel;
using FjernVarmeFyn.Models;
using FjernVarmeFyn.Persistance;
using FjernVarmeFyn.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FjernVarmeFyn.Views
{
    /// <summary>
    /// Interaction logic for UserSendFeedback.xaml
    /// </summary>
    public partial class UserSendFeedback : Page
    {
        private readonly MainViewModel _mainViewModel;
        private Button _selectedButton = null;
        public ObservableCollection<TempFeedbackModel> FeedbackItems { get; set; }

        public UserSendFeedback()
        {
            InitializeComponent();
            _mainViewModel = App.ServiceProvider.GetRequiredService<MainViewModel>();
            DataContext = _mainViewModel.FeedbackViewModel;
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

                // Get the parent frame dynamically
                Frame parentFrame = Window.GetWindow(this)?.FindName("MainFrame") as Frame;
                if (parentFrame != null)
                {
                    UserSendFeedback userSendFeedback = new UserSendFeedback();
                    userSendFeedback.DataContext = _mainViewModel.FeedbackViewModel;
                    parentFrame.Navigate(userSendFeedback);
                }
                else
                {
                    MessageBox.Show("MainFrame not found!");
                }
            }
        }

    }
}
