using Microsoft.AspNetCore.Mvc;
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
    public class RoomService : IRoomService
    {
        string connectionString;
        private IConfiguration configuration;

        public RoomService(IConfiguration conf)
        {
            configuration = conf;
            connectionString = configuration.GetConnectionString("SAMSContext");
        }

        public List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();
            string query = "select * from Room";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Room room = new Room();
                        room.Place_no = Convert.ToInt32(reader[0]);
                        room.Room_No = Convert.ToInt32(reader[3]);
                        room.Rent_Per_Semester = Convert.ToInt32(reader[1]);
                        room.Occupied = Convert.ToBoolean(reader[2]);

                        rooms.Add(room);
                    }
                }
                return rooms;
            }
        }

        public List<Room> GetRoomsInRange(int id, string type)
        {
            string query;

            if (type == "Dormitory")
            {
                query = "select * from Room where Occupied = 'false' and Dormitory_No = " + id;
            }
            else
            {
                query = "select * from Room where Occupied = 'false' and Appart_No = " + id;
            }

            List<Room> rooms = new List<Room>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Room room = new Room();
                        room.Place_no = Convert.ToInt32(reader[0]);
                        room.Room_No = Convert.ToInt32(reader[3]);
                        room.Rent_Per_Semester = Convert.ToInt32(reader[1]);
                        room.Occupied = Convert.ToBoolean(reader[2]);

                        rooms.Add(room);
                    }
                }
                return rooms;
            }
        }

    }
}
