using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FjernVarmeFyn.Models;
using Microsoft.Data.SqlClient;

namespace FjernVarmeFyn.Repositories
{
    class FeedbackRepository : IRepository<Feedback>
    {
        private string _connectionString;

        //Constructor
        public FeedbackRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        //implementation of irepository GetAll
        public List<Feedback> GetAll()
        {
            List<Feedback> feedbackList = new List<Feedback>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Feedback", connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Feedback feedback = new Feedback(
                            (string)reader["FeedbackSubject"],
                            (string)reader["Description"],
                            (Criticality)Enum.Parse(typeof(Criticality), (string)reader["Criticality"]),
                            (string)reader["System"],
                            (FeedbackType)Enum.Parse(typeof(FeedbackType), (string)reader["FeedbackType"]),
                            (int)reader["UserID"]
                        );
                        feedback.FeedbackID = (int)reader["FeedbackID"];
                        feedback.Status = (FeedbackStatus)Enum.Parse(typeof(FeedbackStatus), (string)reader["FeedbackStatus"]);
                        feedbackList.Add(feedback);
                    }
                }
            }

            return feedbackList;
        }

        public List<Feedback> GetFeedbackByUserID(int userID)
        {
            List<Feedback> feedbackList = new List<Feedback>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Feedback WHERE UserID = @UserID", connection);
                command.Parameters.AddWithValue("@UserID", userID);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Feedback feedback = new Feedback(
                            (string)reader["FeedbackSubject"],
                            (string)reader["Description"],
                            (Criticality)Enum.Parse(typeof(Criticality), (string)reader["Criticality"]),
                            (string)reader["System"],
                            (FeedbackType)Enum.Parse(typeof(FeedbackType), (string)reader["Type"]),
                            (int)reader["UserID"]
                        );
                        feedback.FeedbackID = (int)reader["FeedbackID"];
                        feedback.Status = (FeedbackStatus)Enum.Parse(typeof(FeedbackStatus), (string)reader["Status"]);
                        feedbackList.Add(feedback);
                    }
                }
            }

            return feedbackList;
        }

        public void Update(Feedback entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(
                    "UPDATE Feedback SET FeedbackSubject = @FeedbackSubject, Description = @Description, System = @System, Criticality = @Criticality, FeedbackStatus = @FeedbackStatus, FeedbackType = @FeedbackType, UserID = @UserID WHERE FeedbackID = @FeedbackID",
                    connection
                );

                command.Parameters.AddWithValue("@FeedbackID", entity.FeedbackID);
                command.Parameters.AddWithValue("@FeedbackSubject", entity.FeedbackSubject);
                command.Parameters.AddWithValue("@Description", entity.Description);
                command.Parameters.AddWithValue("@System", entity.System);
                command.Parameters.AddWithValue("@Criticality", entity.Criticality.ToString());
                command.Parameters.AddWithValue("@FeedbackStatus", entity.Status.ToString());
                command.Parameters.AddWithValue("@FeedbackType", entity.Type.ToString());
                command.Parameters.AddWithValue("@UserID", entity.UserID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateAdminCriticality(int feedbackID, Criticality adminCriticality)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(
                    "UPDATE Feedback SET AdminCriticality = @AdminCriticality WHERE FeedbackID = @FeedbackID",
                    connection
                );

                command.Parameters.AddWithValue("@FeedbackID", feedbackID);
                command.Parameters.AddWithValue("@AdminCriticality", adminCriticality.ToString());

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Create(Feedback entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(
                    "INSERT INTO Feedback (FeedbackSubject, Description, Criticality, System, FeedbackStatus, FeedbackType, UserID) " +
                    "VALUES (@FeedbackSubject, @Description, @Criticality, @System, @FeedbackStatus, @FeedbackType, @UserID)",
                    connection
                );

                command.Parameters.AddWithValue("@FeedbackSubject", entity.FeedbackSubject);
                command.Parameters.AddWithValue("@Description", entity.Description);
                command.Parameters.AddWithValue("@Criticality", entity.Criticality.ToString());
                command.Parameters.AddWithValue("@System", entity.System);
                command.Parameters.AddWithValue("@FeedbackStatus", entity.Status.ToString());
                command.Parameters.AddWithValue("@FeedbackType", entity.Type.ToString());
                command.Parameters.AddWithValue("@UserID", entity.UserID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void Delete(Feedback entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("DELETE FROM Feedback WHERE FeedbackID = @FeedbackID", connection);
                command.Parameters.AddWithValue("@FeedbackID", entity.FeedbackID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void Dispose()
        {
        }
    }
}
