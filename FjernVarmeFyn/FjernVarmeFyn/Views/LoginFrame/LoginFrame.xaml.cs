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
using System.Windows.Shapes;

namespace FjernVarmeFyn.Views
{
    /// <summary>
    /// Interaction logic for LoginFrame.xaml
    /// </summary>
    public partial class LoginFrame : Window
    {
        private LoginFrame loginFrame;
        public LoginFrame()
        {
            InitializeComponent();
            loginFrame = this;
            this.DataContext = loginFrame;

            this.PageHolder.Content = new Login(loginFrame);
        }
    }
}
