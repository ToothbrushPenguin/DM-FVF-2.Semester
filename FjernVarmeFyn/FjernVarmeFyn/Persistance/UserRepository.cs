using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using FjernVarmeFyn.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace FjernVarmeFyn.Persistance
{
    public class UserRepository
    {
        private readonly string ConnectionString;
        private List<User> users = new List<User>();

        public UserRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            ConnectionString = config.GetConnectionString("DB_Key");
        }

        // UserName: string, Password: string, Email: string, PhoneNr: string, Group: enum
        public void Create(string userName, string password, string email, string phoneNR, Group group)
        {
            User newUser = new User();
            {
                newUser.UserName = userName;
                newUser.Password = password;
                newUser.Email = email;
                newUser.PhoneNR = phoneNR;
                newUser.Group = group;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO USERS (UserName, Password, Email, PhoneNR, Group)" +
                    "VALUES(@UserName,@Password,@Email,@PhoneNR,@Group)" +
                    "SELECT @@IDENTITY", con))
                {
                    cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = newUser.UserName;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = newUser.Password;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = newUser.Email;
                    cmd.Parameters.Add("@PhoneNR", SqlDbType.NVarChar).Value = newUser.PhoneNR;
                    cmd.Parameters.Add("@Group", SqlDbType.NVarChar).Value = newUser.Group.ToString();

                    newUser.UserID = Convert.ToInt32(cmd.ExecuteScalar());
                    users.Add(newUser);
                }
            }
        }
        public User Read(int id)
        {
            User? readUser = null;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, UserName, Password, Email, PhoneNR, Group FROM Users WHERE UserID = @ID", con);
                cmd.Parameters.AddWithValue("@ID", id);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        readUser = new User();
                        {
                            readUser.UserID = dr.GetInt32(0);
                            readUser.UserName = dr.GetString(1);
                            readUser.Password = dr.GetString(2);
                            readUser.Email = dr.GetString(3);
                            readUser.PhoneNR = dr.GetString(4);

                            Group gp = Enum.Parse<Group>(dr.GetString(5));
                            readUser.Group = gp;
                        }
                    }
                }
            }
            return readUser;
        }

        public List<User> GetAll()
        {
            using (SqlConnection Con = new SqlConnection(ConnectionString))
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, UserName, Password, AccessLevel FROM Users", Con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        User getUsers = new User();
                        {
                            getUsers.UserID = dr.GetInt32(0);
                            getUsers.UserName = dr.GetString(1);
                            getUsers.Password = dr.GetString(2);
                            getUsers.Email = dr.GetString(3);
                            getUsers.PhoneNR = dr.GetString(4);

                            Group gp = Enum.Parse<Group>(dr.GetString(5));
                            getUsers.Group = gp;
                        };
                        users.Add(getUsers);
                    }
                }
            }
            return users;
        }
        public void Update(User userToBeUpdated)
        {
            //Skal laves senere

        }
        public void Delete(int? id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE id = @ID", con);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
