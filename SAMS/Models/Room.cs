using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Models
{
    public class Room
    {
        public int Place_no { get; set; }

        public int Room_No { get; set; }

        public double Rent_Per_Semester { get; set; }

        public bool Occupied { get; set; }

    }
}
