using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FjernVarmeFyn.Models
{
    public class ProgramRepository
    {
        private readonly string ConnectionString;
        private List<Program> programs = new List<Program>();
        private UserRepository userRepo;


        public ProgramRepository(UserRepository userRepo)
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            ConnectionString = config.GetConnectionString("DB_Key");
            this.userRepo = userRepo;
        }


        public void Create(User user, string description)
        {
            Program newProgram = new Program();
            {
                newProgram.systemUser = user;
                newProgram.Description = description;
            }

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO PROGRAMS (Description, systemUser)" +
                    "VALUES(@Description, @systemUser)" +
                    "SELECT @@IDENTITY", con))
                {
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = newProgram.Description;
                    cmd.Parameters.Add("@systemUser", SqlDbType.NVarChar).Value = newProgram.systemUser;

                    newProgram.ProgramID = Convert.ToInt32(cmd.ExecuteScalar());
                    programs.Add(newProgram);
                }
            }
        }

        public Program Read(int ID)
        {
            Program? readProgram = null;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Description, systemUser FROM PROGRAMS WHERE ProgramID = @ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);

                using (SqlDataReader dr =  cmd.ExecuteReader())
                {
                    readProgram = new Program();
                    {
                        readProgram.ProgramID = dr.GetInt32(0);
                        readProgram.Description = dr.GetString(1);


                        // Når ProgramRepository instnaseres SKAL UserRepository instanseres først og fyldes op
                        // Og så skal UserRepo passes igennem ProgramRepo constructor, for at pisset virker
                        int uid = dr.GetInt32(2);
                        readProgram.systemUser = userRepo.Read(uid);
                    }
                }
            }
            return readProgram;
        }

        public List<Program> GetAll()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Description, systemUser FROM PROGRAMS");
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Program program = new Program();
                        {
                            program.ProgramID = dr.GetInt32(0);
                            program.Description = dr.GetString(1);


                            // Når ProgramRepository instnaseres SKAL UserRepository instanseres først og fyldes op
                            // Og så skal UserRepo passes igennem ProgramRepo constructor, for at pisset virker
                            int uid = dr.GetInt32(2);
                            program.systemUser = userRepo.Read(uid);
                        }
                        programs.Add(program);
                    }
                }
            }
            return programs;
        }


        public void Update()
        {
            //Skal laves Senere
        }

        public void Delete(int programId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM PROGRAMS WHERE programId = @ID");
                cmd.Parameters.AddWithValue("@ID", programId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
