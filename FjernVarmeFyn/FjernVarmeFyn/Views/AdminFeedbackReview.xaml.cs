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
    /// Interaction logic for AdminFeedbackReview.xaml
    /// </summary>
    public partial class AdminFeedbackReview : Page
    {
        private Button _selectedButton = null;
        public AdminFeedbackReview()
        {
            InitializeComponent();
        }

        private void FeedBack_Click(object sender, RoutedEventArgs e)
        {
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
                        parentFrame.Navigate(new UserSendFeedback());
                    }
                    else
                    {
                        MessageBox.Show("MainFrame not found!");
                    }
                }
            }
        }
    }
}
