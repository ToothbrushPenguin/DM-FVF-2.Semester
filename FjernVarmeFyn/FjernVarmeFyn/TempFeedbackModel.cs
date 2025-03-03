using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace FjernVarmeFyn
{
    public class TempFeedbackModel : INotifyPropertyChanged
    {
        private string _emne;
        private string _ticket;
        private string _system;
        private string _status;
        private string _adminPriority;
        private string _priority;
        private string _description;

        public string Emne
        {
            get { return _emne; }
            set
            {
                if (_emne != value)
                {
                    _emne = value;
                    OnPropertyChanged(nameof(Emne));
                }
            }
        }


        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public string Ticket
        {
            get { return _ticket; }
            set
            {
                if (_ticket != value)
                {
                    _ticket = value;
                    OnPropertyChanged(nameof(Ticket));
                }
            }
        }

        public string System
        {
            get { return _system; }
            set
            {
                if (_system != value)
                {
                    _system = value;
                    OnPropertyChanged(nameof(System));
                }
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public string AdminPriority
        {
            get { return _adminPriority; }
            set
            {
                if (_adminPriority != value)
                {
                    _adminPriority = value;
                    OnPropertyChanged(nameof(AdminPriority));
                }
            }
        }

        public string Priority
        {
            get { return _priority; }
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    OnPropertyChanged(nameof(Priority));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
