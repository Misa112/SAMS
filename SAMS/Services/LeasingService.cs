using Microsoft.Extensions.Configuration;
using SAMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Services
{
    public class LeasingService: Interfaces.ILeasingService
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
                        leasing.Date_From = Convert.ToDateTime(reader[0]);
                        leasing.Date_To = Convert.ToDateTime(reader[0]);

                        leasings.Add(leasing);
                    }
                }
                return leasings;
            }
        }
    }
}
