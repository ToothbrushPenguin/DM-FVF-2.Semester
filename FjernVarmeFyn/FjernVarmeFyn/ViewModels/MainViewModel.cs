using FjernVarmeFyn.Models;
using FjernVarmeFyn.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FjernVarmeFyn.ViewModels
{
    public class MainViewModel
    {
        public FeedbackViewModel FeedbackViewModel { get; }

        public MainViewModel(FeedbackViewModel feedbackViewModel)
        {
            FeedbackViewModel = feedbackViewModel;
        }
        public MainViewModel() { }
    }

}
