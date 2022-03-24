using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMS.Models
{
    public class StudentInfo
    {
        public int Student_No { get; set; }
        public string SName { get; set; }
        public int Leasing_No { get; set; }
        public int Room_No { get; set; }
        public int? Dormitory_No { get; set; }
        public int? Appart_No { get; set; }
    }
}
