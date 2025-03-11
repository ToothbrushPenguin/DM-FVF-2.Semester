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
using FjernVarmeFyn.Repositories;
using FjernVarmeFyn.ViewModels;

namespace FjernVarmeFyn.Views
{
    /// <summary>
    /// Interaction logic for UserSendFeedback.xaml
    /// </summary>
    public partial class UserSendFeedback : Page
    {
        public ObservableCollection<TempFeedbackModel> FeedbackItems { get; set; }

        public UserSendFeedback()
        {
            InitializeComponent();

            // Initialize the collection with some sample data
            // In a real application, this would come from a database or service
            FeedbackItems = new ObservableCollection<TempFeedbackModel>
            {
                new TempFeedbackModel
                {
                    Emne = "Problem med login",
                    Ticket = "T-1001",
                    System = "Login",
                    Status = "Åben",
                    AdminPriority = "2",
                    Priority = "5"
                },
                new TempFeedbackModel
                {
                    Emne = "Fejl i rapportmodul",
                    Ticket = "T-1002",
                    System = "Rapporter",
                    Status = "Under behandling",
                    AdminPriority = "1",
                    Priority = "3"
                },
                new TempFeedbackModel
                {
                    Emne = "Forslag til ny funktion",
                    Ticket = "T-1003",
                    System = "Dashboard",
                    Status = "Åben",
                    AdminPriority = "3",
                    Priority = "4"
                }
            };

            IRepository<Feedback> feedbackRepository = new FeedbackRepository("Server=localhost\\SQLEXPRESS;Database=feedbacktest;Trusted_Connection=True;TrustServerCertificate=true");
            this.DataContext = new FeedbackViewModel(feedbackRepository);
        }


    }
}
