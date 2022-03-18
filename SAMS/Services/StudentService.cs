using Microsoft.Extensions.Configuration;
using SAMS.Interfaces;
using SAMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace SAMS.Services
{
    public class StudentService : IStudentService
    {
        string connectionString;
        private IConfiguration configuration;
        public StudentService(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("SAMSContext");
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            string query = "select *  from Student";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.Student_No = Convert.ToInt32(reader[0]);
                        student.SName = Convert.ToString(reader[1]);
                        student.SAddress = Convert.ToString(reader[2]);
                        student.Has_Room = Convert.ToBoolean(reader[3]);
                        student.RegistrationDate = Convert.ToDateTime(reader[4]);

                        students.Add(student);
                    }
                }
                return students;
            }
        }
    }
}
