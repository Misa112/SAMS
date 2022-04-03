using Microsoft.Extensions.Configuration;
using SAMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Services
{
    public class LeasingService : Interfaces.ILeasingService
    {
        string connectionString;
        private IConfiguration configuration;

        public LeasingService(IConfiguration conf)
        {
            configuration = conf;
            connectionString = configuration.GetConnectionString("SAMSContext");
        }

        public List<Leasing> GetAllLeasings()
        {
            List<Leasing> leasings = new List<Leasing>();
            string query = "select * from Leasing";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Leasing leasing = new Leasing();
                        leasing.Leasing_No = Convert.ToInt32(reader[0]);
                        leasing.Date_From = Convert.ToDateTime(reader[3]);
                        leasing.Date_To = Convert.ToDateTime(reader[4]);
                        leasing.Student_No = Convert.ToInt32(reader[1]);
                        leasing.Place_No = Convert.ToInt32(reader[2]);

                        leasings.Add(leasing);
                    }
                }
                return leasings;
            }
        }

        public void AddLeasing(int student_id, int place_id)
        {
            DateTime date_from = DateTime.Now;
            DateTime date_to = date_from.AddMonths(6);

            string query = "insert into Leasing(Student_No, Place_No, Date_From, Date_To)" +
                           $"VALUES ({student_id}, {place_id}, '{date_from}', '{date_to}');";

            string query1 = $"update Student set Has_Room = 1 where Student_No = {student_id};";

            string query2 = $"update Room set Occupied = 1 where Place_No = {place_id};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    command.ExecuteNonQuery();
                }

            }
        }
    }
}