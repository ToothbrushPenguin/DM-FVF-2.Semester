using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FjernVarmeFyn.Models
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public string FeedbackSubject { get; set; }
        public string Description { get; set; }
        public string System { get; set; }
        public Criticality Criticality { get; set; }
        public FeedbackStatus Status { get; set; }
        public FeedbackType Type { get; set; }
        public int UserID { get; set; }

        public Feedback() { }

        public Feedback(string feedbackSubject, string description, Criticality criticality, string system, FeedbackType type, int userID)
        {
            FeedbackSubject = feedbackSubject;
            Description = description;
            Criticality = criticality;
            System = system;
            Type = type;
            UserID = userID;
            Status = FeedbackStatus.Åben; // Default
        }
    }
}
