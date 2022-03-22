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
    public class DormitoryService : IDormitoryService
    {
        string connectionString;
        private IConfiguration configuration;
        public DormitoryService(IConfiguration config)
        {
            configuration = config;
            connectionString = configuration.GetConnectionString("SAMSContext");
        }
        public List<Dormitory> GetAllDormitories()
        {
            List<Dormitory> dormitories = new List<Dormitory>();
            string query = "select *  from Dormitory";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Dormitory dormitory = new Dormitory();
                        dormitory.Dormitory_No = Convert.ToInt32(reader[0]);
                        dormitory.Name = Convert.ToString(reader[1]);
                        dormitory.Address = Convert.ToString(reader[2]);
                        
                        dormitories.Add(dormitory);
                    }
                }
                return dormitories;
            }
        }
    }
}
