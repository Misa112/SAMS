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

        public StudentInfo GetStudentInfo(int id)
        {
            StudentInfo student = new StudentInfo();
            string query =
                "select Student.Student_No, Student.SName, " +
                "Leasing.Leasing_No, Room.Room_No, " +
                "Room.Dormitory_No, Room.Appart_No " +
                "from Student " +
                "join Leasing on Student.Student_No = Leasing.Student_No " +
                "join Room on Leasing.Place_No = Room.Place_No " +
                "where Student.Student_No = " + id;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        student.Student_No = Convert.ToInt32(reader[0]);
                        student.SName = Convert.ToString(reader[1]);
                        student.Leasing_No = Convert.ToInt32(reader[2]);
                        student.Room_No = Convert.ToInt32(reader[3]);

                        if (Convert.IsDBNull(student.Dormitory_No) || student.Dormitory_No is null || student.Appart_No == 0)
                            student.Dormitory_No = 0;
                        else
                            student.Dormitory_No = Convert.ToInt32(reader[4]);


                        if (Convert.IsDBNull(student.Appart_No) || student.Appart_No is null || student.Appart_No == 0)
                            student.Appart_No = 0;
                        else
                            student.Appart_No = Convert.ToInt32(reader[5]);
                    }
                }
                return student;
            }
        }

        public List<Student> GetWaitingList()
        {
            List<Student> students = new List<Student>();
            string query = "select * from Student where Has_Room = 'false' order by Registration_Date asc";

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


        public void DeleteStudent(int student_id)
        {
            string query = $"delete from Student where Student_No = {student_id};";

            //assume that in database is 'delete on cascade' and dont deal with deleting relations

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
