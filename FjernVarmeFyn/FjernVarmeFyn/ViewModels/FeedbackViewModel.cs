using FjernVarmeFyn;
using FjernVarmeFyn.Models;
using FjernVarmeFyn.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Data.SqlClient;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Microsoft.Data.SqlClient;




namespace FjernVarmeFyn.ViewModels
{
    class FeedbackViewModel : INotifyPropertyChanged
    {
        private readonly IRepository<Feedback> _feedbackRepository;
        public IRelayCommand SubmitFeedbackCommand { get; }
        public IRelayCommand UpdateFeedbackCommand { get; }
        private ObservableCollection<Feedback> _feedbackList = new ObservableCollection<Feedback>();

        public ObservableCollection<Feedback> FeedbackList
        {
            get => _feedbackList;
            set
            {
                _feedbackList = value;
                OnPropertyChanged(nameof(FeedbackList));
            }
        }

        private Feedback _currentFeedback;
        public Feedback CurrentFeedback
        {
            get => _currentFeedback;
            set
            {
                _currentFeedback = value;
                OnPropertyChanged(nameof(CurrentFeedback));
            }
        }

        private Feedback _selectedFeedback;
        public Feedback SelectedFeedback
        {
            get => _selectedFeedback;
            set
            {
                _selectedFeedback = value;
                if (_selectedFeedback != null)
                {
                    CurrentFeedback = new Feedback
                    {
                        FeedbackID = _selectedFeedback.FeedbackID, 
                        FeedbackSubject = _selectedFeedback.FeedbackSubject,
                        Description = _selectedFeedback.Description,
                        System = _selectedFeedback.System,
                        Criticality = _selectedFeedback.Criticality,
                        Status = _selectedFeedback.Status,
                        Type = _selectedFeedback.Type,
                        UserID = _selectedFeedback.UserID
                    };

                }
                else
                {
                    CurrentFeedback = new Feedback();
                }

                OnPropertyChanged(nameof(SelectedFeedback));
            }
        }

        public List<Criticality> CriticalityList { get; set; }

        public FeedbackViewModel(IRepository<Feedback> feedbackRepository)
        {
            CurrentFeedback = new Feedback();
            _feedbackRepository = feedbackRepository;
            UpdateFeedbackCommand = new RelayCommand(UpdateFeedback);
            SubmitFeedbackCommand = new RelayCommand(AddFeedback);
            FeedbackList = new ObservableCollection<Feedback>(_feedbackRepository.GetAll());
        }

        private void AddFeedback()
        {
            if (SelectedFeedback == null)
            {
                Feedback feedback = new Feedback(
                    CurrentFeedback.FeedbackSubject,
                    CurrentFeedback.Description,
                    CurrentFeedback.Criticality,
                    CurrentFeedback.System,
                    CurrentFeedback.Type,
                    CurrentFeedback.UserID = 1
                );

                try
                {
                    _feedbackRepository.Create(feedback);

                    FeedbackList = new ObservableCollection<Feedback>(_feedbackRepository.GetAll());

                    CurrentFeedback = new Feedback();

                    MessageBox.Show("Feedback sent successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"An error occurred while sending feedback: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void UpdateFeedback()
        {
            if (SelectedFeedback != null)
            {
                SelectedFeedback.FeedbackSubject = CurrentFeedback.FeedbackSubject;
                SelectedFeedback.Description = CurrentFeedback.Description;
                SelectedFeedback.System = CurrentFeedback.System;
                SelectedFeedback.Criticality = CurrentFeedback.Criticality;
                SelectedFeedback.Status = CurrentFeedback.Status;
                SelectedFeedback.Type = CurrentFeedback.Type;

                _feedbackRepository.Update(SelectedFeedback); 

                OnPropertyChanged(nameof(FeedbackList));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
