using FjernVarmeFyn.ViewModels;
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
using FjernVarmeFyn.ViewModels;
using FjernVarmeFyn.Models;
using FjernVarmeFyn.Repositories;

namespace FjernVarmeFyn.Views
{
    /// <summary>
    /// Interaction logic for FeedbackPage.xaml
    /// </summary>
    public partial class FeedbackPage : Page
    {
        public FeedbackPage()
        {
            InitializeComponent();
            IRepository<Feedback> feedbackRepository = new FeedbackRepository("Server=.\\SQLEXPRESS;Database=feedbacktest;Integrated Security=True;");
            this.DataContext = new FeedbackViewModel(feedbackRepository);
        }

    }
}
