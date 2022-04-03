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
    public class ApartmentService : IApartmentService
    {
        string connectionString;
        private IConfiguration configuration;

        public ApartmentService(IConfiguration conf)
        {
            configuration = conf;
            connectionString = configuration.GetConnectionString("SAMSContext");
        }

        public List<Apartment> GetAllApartments()
        {
            List<Apartment> apartments = new List<Apartment>();
            string query = "select * from Appartment";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Apartment apartment = new Apartment();
                        apartment.Apart_No = Convert.ToInt32(reader[0]);
                        apartment.Address = Convert.ToString(reader[1]);
                        apartment.Types = Convert.ToInt32(reader[2]);

                        apartments.Add(apartment);
                    }
                }
                return apartments;
            }
        }
    }
}
